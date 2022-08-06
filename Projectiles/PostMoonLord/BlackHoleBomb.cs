using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PostMoonLord
{
	public class BlackHoleBomb : ECProjectile
	{
		bool doOnce = false;

		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.DontAttachHideToAlpha[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			projectile.hide = true;
			projectile.noEnchantments = true;
			maxVel = 16f;
			whizze = false;
			rotate = false;
			loopingSound = "Sounds/BlackHoleBombLoop";
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}

		public override void PostAI()
		{
			/*if (projectile.velocity.X != 0)
				projectile.spriteDirection = Math.Sign(projectile.velocity.X);*/
			if (projectile.owner == Main.myPlayer && !doOnce)
			{
				float centerX = projectile.position.X;
				float centerY = projectile.position.Y;
				int projCheck = Projectile.NewProjectile((int)centerX, (int)centerY, 0, 0, mod.ProjectileType("BlackHoleBombProj"), (int)(projectile.damage), projectile.knockBack, Main.player[projectile.owner].whoAmI, projectile.whoAmI);
				//if (projectile.velocity.X != 0)
				Main.projectile[projCheck].direction = Main.player[projectile.owner].direction;
				doOnce = true;
			}
		}

		public override bool? CanCutTiles()
		{
			return false;
		}

		public override bool? CanHitNPC(NPC npc)
		{
			return false;
		}

		public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
		{
			drawCacheProjsBehindNPCs.Add(index);
		}
	}
}
