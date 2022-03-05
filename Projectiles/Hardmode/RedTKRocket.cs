using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Projectiles.Hardmode
{
	public class RedTKRocket : ECProjectile
	{
		bool doOnce = false;
		Vector2 targetPos = Vector2.Zero;
		int effectTimer = 0;
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = 1;
			maxVel = 12f;
			rotate = false;
			whizze = false;
			canReturn = false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 5;
			base.OnHitNPC(target, damage, knockback, crit);
		}

		public override void PostAI()
		{
			if (projectile.velocity != Vector2.Zero)
			{
				projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.5f;
				targetPos.X = Main.mouseX + Main.screenPosition.X + projectile.velocity.X;
				targetPos.Y = Main.mouseY + Main.screenPosition.Y + projectile.velocity.Y;
			}
		}

		public override void ExtraAI()
		{
			if (!held)
			{
				if (!doOnce)
				{
					if (projectile.velocity == Vector2.Zero)
					{
						Vector2 shootVel = targetPos - projectile.Center;
						projectile.velocity = shootVel;
					}
					projectile.velocity.Normalize();
					projectile.timeLeft = 180;
					doOnce = true;
				}
				projectile.velocity *= 1.1f;
				effectTimer++;
				if (effectTimer == 1)
				{
					for (int num1183 = 0; num1183 < 8; num1183++)
					{
						int num1184 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.8f);
						Main.dust[num1184].noGravity = true;
						Dust dust81 = Main.dust[num1184];
						dust81.velocity *= 3f;
						Main.dust[num1184].fadeIn = 0.5f;
						dust81 = Main.dust[num1184];
						dust81.position += projectile.velocity / 2f;
						dust81 = Main.dust[num1184];
						dust81.velocity += projectile.velocity / 4f + Main.player[projectile.owner].velocity * 0.1f;
					}
				}
				if (effectTimer > 2)
				{
					int num1188 = Dust.NewDust(new Vector2(projectile.position.X + 2f, projectile.position.Y + 20f), 8, 8, 6, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.2f);
					Main.dust[num1188].noGravity = true;
					Dust dust81 = Main.dust[num1188];
					dust81.velocity *= 0.2f;
					Main.dust[num1188].position = Main.dust[num1188].position.RotatedBy(projectile.rotation, projectile.Center);
					num1188 = Dust.NewDust(new Vector2(projectile.position.X + 2f, projectile.position.Y + 15f), 8, 8, 6, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.2f);
					Main.dust[num1188].noGravity = true;
					dust81 = Main.dust[num1188];
					dust81.velocity *= 0.2f;
					Main.dust[num1188].position = Main.dust[num1188].position.RotatedBy(projectile.rotation, projectile.Center);
					num1188 = Dust.NewDust(new Vector2(projectile.position.X + 2f, projectile.position.Y + 10f), 8, 8, 6, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.2f);
					Main.dust[num1188].noGravity = true;
					dust81 = Main.dust[num1188];
					dust81.velocity *= 0.2f;
					Main.dust[num1188].position = Main.dust[num1188].position.RotatedBy(projectile.rotation, projectile.Center);
				}
			}
			base.ExtraAI();
		}

		public virtual void ExplosiveEffect()
		{
			for (int num481 = 0; num481 < 400; num481++)
			{
				float num480 = 16f;
				if (num481 < 300)
				{
					num480 = 12f;
				}
				if (num481 < 200)
				{
					num480 = 8f;
				}
				if (num481 < 100)
				{
					num480 = 4f;
				}
				int num479 = 130;
				int num477 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 6, 6, num479, 0f, 0f, 100);
				float num476 = Main.dust[num477].velocity.X;
				float num475 = Main.dust[num477].velocity.Y;
				if (num476 == 0f && num475 == 0f)
				{
					num476 = 1f;
				}
				float num474 = (float)Math.Sqrt(num476 * num476 + num475 * num475);
				num474 = num480 / num474;
				num476 *= num474;
				num475 *= num474;
				Dust dust24 = Main.dust[num477];
				dust24.velocity *= 0.5f;
				Dust expr_152EB_cp_0 = Main.dust[num477];
				expr_152EB_cp_0.velocity.X = expr_152EB_cp_0.velocity.X + num476;
				Dust expr_1530A_cp_0 = Main.dust[num477];
				expr_1530A_cp_0.velocity.Y = expr_1530A_cp_0.velocity.Y + num475;
				Main.dust[num477].scale = 1.3f;
				Main.dust[num477].noGravity = true;
			}
		}

		public override void Kill(int timeLeft)
		{
			if (held)
				Main.player[projectile.owner].channel = false;
			Main.PlaySound(SoundID.Item14, projectile.position);
			ExplosiveEffect();
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = (int)(192f * projectile.scale);
			projectile.height = (int)(192f * projectile.scale);
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			if (projectile.owner == Main.myPlayer)
			{
				projectile.localAI[1] = -1f;
				projectile.maxPenetrate = 0;
				projectile.Damage();
			}
			base.Kill(timeLeft);
		}
	}
}
