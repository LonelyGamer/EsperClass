using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class LiquidNitrogenCanister : ECProjectile
	{
		int release = 0;
		protected int releaseRate;
		protected int projType;
		protected float pourSpeed;

		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.DontAttachHideToAlpha[projectile.type] = true;
		}
 


		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 30;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			projectile.hide = true;
			projectile.noEnchantments = true;
			maxVel = 16f;
			whizze = false;
			rotate = false;
			releaseRate = 15;
			projType = mod.ProjectileType("LiquidNitrogenCanisterProj");
			pourSpeed = 12f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.position -= projectile.velocity;
		if ((double)projectile.velocity.X != (double)oldVelocity.X)
			projectile.velocity.X = -oldVelocity.X;
		if ((double)projectile.velocity.Y != (double)oldVelocity.Y)
			projectile.velocity.Y = -oldVelocity.Y;
				return false;
		}

		public override void PostAI()
		{
			if (!held)
			{
				return;
			}
			release += 1;
			if (release >= releaseRate)
			{
				release = 0;
				if (projectile.owner == Main.myPlayer)
				{
					Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
					Projectile.NewProjectile(vector.X, vector.Y, 0, pourSpeed, projType, (int)(projectile.damage), projectile.knockBack, Main.player[projectile.owner].whoAmI);
				}
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
