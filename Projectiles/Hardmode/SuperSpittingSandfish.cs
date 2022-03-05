using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class SuperSpittingSandfish : ECProjectile
	{
		int fireDelay = 0;
		Vector2 targetPos = Vector2.Zero;

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
			return false;
		}

		public override void PostAI()
		{
			if (projectile.velocity != Vector2.Zero)
			{
				projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 0.785f;
				targetPos.X = Main.mouseX + Main.screenPosition.X + projectile.velocity.X;
				targetPos.Y = Main.mouseY + Main.screenPosition.Y + projectile.velocity.Y;
			}
			if (!held)
			{
				return;
			}
			fireDelay += 1;
			if (fireDelay >= 30)
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
					for (int i = -1; i < 2; i++)
					{
						double dir = 90 - (float)System.Math.Atan2((double)shootVel.X, (double)shootVel.Y) * 180 / Math.PI + (5f * i);
						float vX = 16 * (float)Math.Cos(dir / 180 * Math.PI);
						float vY = 16 * (float)Math.Sin(dir / 180 * Math.PI);
						Vector2 velocity = new Vector2(vX, vY);
						//Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
						Vector2 center = projectile.Center;
						Projectile.NewProjectile(center, velocity, mod.ProjectileType("SuperSpittingSandfishProj"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
					}
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
