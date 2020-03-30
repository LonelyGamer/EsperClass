using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class ClotBomber : ECProjectile
	{
		int fireTimer = 0;

		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.DontAttachHideToAlpha[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
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
			projectile.position -= projectile.velocity;
			if ((double)projectile.velocity.X != (double)oldVelocity.X)
				projectile.velocity.X = -oldVelocity.X;
			if ((double)projectile.velocity.Y != (double)oldVelocity.Y)
				projectile.velocity.Y = -oldVelocity.Y;
			return false;
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 20;
			height = 20;
			return true;
		}

		public override void PostAI()
		{
			if (!held)
			{
				return;
			}
			if (projectile.velocity.X != 0)
				projectile.spriteDirection = Math.Sign(projectile.velocity.X);
			fireTimer += 1;
			if (fireTimer >= 30)
			{
				fireTimer = 0;
				if (projectile.owner == Main.myPlayer)
				{
					Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
					int projCheck = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, mod.ProjectileType("ClotBomberProj"), (int)(projectile.damage), projectile.knockBack, Main.player[projectile.owner].whoAmI);
					Main.projectile[projCheck].spriteDirection = projectile.spriteDirection;
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
