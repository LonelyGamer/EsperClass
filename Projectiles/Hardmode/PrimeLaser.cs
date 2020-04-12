using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class PrimeLaser : BaseRiftProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 22;
			projectile.height = 28;
			Main.projFrames[projectile.type] = 4;
			rotate = false;
			projType = mod.ProjectileType("PrimeLaserProj");
			fireDelay = 30;
			fireVel = 16f;
		}

		public override void PostAI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 9)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame > 3)
				{
					projectile.frame = 0;
				}
			}
			if (!held)
			{
				return;
			}
			//Adapted from AI_134_Ballista
			int target = -1;
			target = this.GetTarget(400, projectile.Center);
			fireTimer++;
			if (target != -1)
			{
				Vector2 vector = (Main.npc[target].Center - projectile.Center).SafeNormalize(Vector2.UnitY);
				projectile.rotation = vector.ToRotation() - 1.57f;
				if (projectile.rotation > 1.57079637f || projectile.rotation < -1.57079637f)
				{
					projectile.direction = -1;
				}
				else
				{
					projectile.direction = 1;
				}
				if (projectile.owner == Main.myPlayer)
				{
					projectile.direction = Math.Sign(vector.X);
					projectile.netUpdate = true;
				}
			}
			else if (projectile.velocity != Vector2.Zero)
				projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 1.57f;
			if (fireTimer >= fireDelay)
			{
				if (target != -1)
				{
					if (Main.myPlayer == projectile.owner)
					{
						fireTimer = 0;
						Vector2 vector2 = (Main.npc[target].Center - projectile.Center).SafeNormalize(Vector2.UnitX * (float)projectile.direction);
						Vector2 velocity = vector2 * fireVel;
						Main.PlaySound(SoundID.Item33, (int)projectile.position.X, (int)projectile.position.Y);
						Projectile.NewProjectile(projectile.Center, velocity, projType, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
					}
				}
			}
		}

		public int GetTarget(float maxRange, Vector2 shootingSpot)
		{
			int first = -1;
			for (int j = 0; j < 200; j++)
			{
				NPC nPC = Main.npc[j];
				if (nPC.CanBeChasedBy(this, false))
				{
					float distance2 = Vector2.Distance(shootingSpot, nPC.Center);
					if (distance2 <= maxRange)
					{
						Vector2 vector2 = (nPC.Center - shootingSpot).SafeNormalize(Vector2.UnitY);
						if ((first == -1 || distance2 < Vector2.Distance(shootingSpot, Main.npc[first].Center)) && Collision.CanHitLine(shootingSpot, 0, 0, nPC.Center, 0, 0))
						{
							first = j;
						}
					}
				}
			}
			return first;
		}
	}
}
