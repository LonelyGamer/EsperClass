using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class SpittingSandfish : ECProjectile
	{
		int fireDelay = 0;
		Vector2 targetPos = Vector2.Zero;

		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.DontAttachHideToAlpha[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 34;
			projectile.height = 34;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.hide = true;
			projectile.noEnchantments = true;
			maxVel = 16f;
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

		public override void PostAI()
		{
			if (projectile.velocity != Vector2.Zero/* && Main.lastMouseX != Main.mouseX && Main.lastMouseY != Main.mouseY*/)
			{
				projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 0.785f;
				targetPos.X = Main.mouseX + Main.screenPosition.X + projectile.velocity.X;
				targetPos.Y = Main.mouseY + Main.screenPosition.Y + projectile.velocity.Y;
			}
			/*if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= 1.57f;
			}*/
			if (!held)
			{
				return;
			}
			fireDelay += 1;
			if (fireDelay >= 15)
			{
				fireDelay = 0;
				if (projectile.owner == Main.myPlayer)
				{
					Vector2 shootVel = targetPos - projectile.Center;
					if (shootVel == Vector2.Zero)
					{
						shootVel = new Vector2(0f, 1f);
					}
					shootVel.Normalize();
					shootVel *= 6;
					Main.PlaySound(SoundID.Item85, projectile.position);
					Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
					int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootVel.X, shootVel.Y, mod.ProjectileType("SpittingSandfishProj"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
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
