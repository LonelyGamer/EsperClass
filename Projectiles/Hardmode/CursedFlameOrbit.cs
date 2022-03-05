using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class CursedFlameOrbit : ECProjectile
	{
		bool doOnce = false;

		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.DontAttachHideToAlpha[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 36;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			projectile.hide = true;
			projectile.noEnchantments = true;
			maxVel = 12f;
			whizze = false;
			rotate = false;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}

		public override void PostAI()
		{
			if (projectile.velocity.X != 0)
				projectile.spriteDirection = Math.Sign(projectile.velocity.X);
			if (projectile.owner == Main.myPlayer && !doOnce)
			{
				float centerX = projectile.position.X;
				float centerY = projectile.position.Y;
				int projCheck = 0;
				for (int i = 0; i < 4; i++)
				{
					projCheck = Projectile.NewProjectile((int)centerX, (int)centerY, 0, 0, mod.ProjectileType("CursedFlameOrbitProj"), (int)(projectile.damage), projectile.knockBack, Main.player[projectile.owner].whoAmI, projectile.whoAmI);
					//Main.projectile[projCheck].spriteDirection = projectile.spriteDirection;
					Main.projectile[projCheck].ai[1] = 90 * i;
				}
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
