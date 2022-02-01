using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class GreekFireProj1 : ECProjectile
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_326";
			}
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 14;
			projectile.height = 16;
			projectile.penetrate = -1;
			projectile.timeLeft = 120;
			//projectile.aiStyle = 14;
		}

		public override void AI()
		{
			if (projectile.wet)
				projectile.Kill();
			if (projectile.ai[1] == 0f)
			{
				projectile.ai[1] = 1f;
				Main.PlaySound(SoundID.Item13, projectile.position);
			}

			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 5f)
			{
				projectile.ai[0] = 5f;
				if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
				{
					projectile.velocity.X = projectile.velocity.X * 0.97f;
					if ((double)projectile.velocity.X > -0.01 && (double)projectile.velocity.X < 0.01)
					{
						projectile.velocity.X = 0f;
						projectile.netUpdate = true;
					}
				}
				projectile.velocity.Y = projectile.velocity.Y + 0.2f;
			}
			projectile.rotation += projectile.velocity.X * 0.1f;

			int num612 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 100);
			Dust expr_8946_cp_0 = Main.dust[num612];
			expr_8946_cp_0.position.X = expr_8946_cp_0.position.X - 2f;
			Dust expr_8964_cp_0 = Main.dust[num612];
			expr_8964_cp_0.position.Y = expr_8964_cp_0.position.Y + 2f;
			Dust dust81 = Main.dust[num612];
			dust81.scale += (float)Main.rand.Next(50) * 0.01f;
			Main.dust[num612].noGravity = true;
			Dust expr_89B7_cp_0 = Main.dust[num612];
			expr_89B7_cp_0.velocity.Y = expr_89B7_cp_0.velocity.Y - 2f;
			if (Main.rand.Next(2) == 0)
			{
				int num623 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 100);
				Dust expr_8A1E_cp_0 = Main.dust[num623];
				expr_8A1E_cp_0.position.X = expr_8A1E_cp_0.position.X - 2f;
				Dust expr_8A3C_cp_0 = Main.dust[num623];
				expr_8A3C_cp_0.position.Y = expr_8A3C_cp_0.position.Y + 2f;
				dust81 = Main.dust[num623];
				dust81.scale += 0.3f + (float)Main.rand.Next(50) * 0.01f;
				Main.dust[num623].noGravity = true;
				dust81 = Main.dust[num623];
				dust81.velocity *= 0.1f;
			}
			if ((double)projectile.velocity.Y < 0.25 && (double)projectile.velocity.Y > 0.15)
			{
				projectile.velocity.X = projectile.velocity.X * 0.8f;
			}
			//projectile.rotation = (0f - projectile.velocity.X) * 0.05f;
		}

		//public override Color? GetAlpha(Color lightColor) => new Color(200, 200, 200, 25);

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.velocity.X != oldVelocity.X)
				projectile.velocity.X = oldVelocity.X * -0.1f;
			return false;
		}
	}
}
