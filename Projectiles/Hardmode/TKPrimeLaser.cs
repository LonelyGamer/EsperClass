using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EsperClass.Projectiles.Hardmode
{
	public class TKPrimeLaser : BaseRiftProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 22;
			projectile.height = 28;
			Main.projFrames[projectile.type] = 4;
			rotate = false;
			projType = mod.ProjectileType("TKPrimeLaserProj");
			fireDelay = 20;
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
						int projCheck = 0;
						projCheck = Projectile.NewProjectile(projectile.Center, velocity, projType, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
						Main.projectile[projCheck].rotation = (float)Math.Atan2((double)Main.projectile[projCheck].velocity.Y, (double)Main.projectile[projCheck].velocity.X) - 1.57f;
					}
				}
			}
		}
	}
}
