using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EsperClass.Projectiles.Hardmode
{
    public class SharknadoRiftProj2 : ECProjectile
	{
		public override string Texture => "Terraria/Projectile_384";

		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 6;
		}

		public override void SetDefaults()
		{
			projectile.width = 150;
			projectile.height = 42;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 60;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

		public override Color? GetAlpha(Color lightColor) => new Color(200, 200, 200, 0);

		public override void AI()
		{
			ExtraAI();
			int num954 = 10;
			int num953 = 15;
			float num952 = 1f;
			int num951 = 150;
			int num950 = 42;
			if (projectile.type == 386)
			{
				num954 = 16;
				num953 = 16;
				num952 = 1.5f;
			}
			if (projectile.velocity.X != 0f)
			{
				projectile.direction = (projectile.spriteDirection = -Math.Sign(projectile.velocity.X));
			}
			projectile.frameCounter++;
			if (projectile.frameCounter > 2)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 6)
			{
				projectile.frame = 0;
			}
			if (projectile.localAI[0] == 0f && Main.myPlayer == projectile.owner)
			{
				projectile.localAI[0] = 1f;
				projectile.position.X += (float)(projectile.width / 2);
				projectile.position.Y += (float)(projectile.height / 2);
				projectile.scale = ((float)(num954 + num953) - projectile.ai[1]) * num952 / (float)(num953 + num954);
				projectile.width = (int)((float)num951 * projectile.scale);
				projectile.height = (int)((float)num950 * projectile.scale);
				projectile.position.X -= (float)(projectile.width / 2);
				projectile.position.Y -= (float)(projectile.height / 2);
				projectile.netUpdate = true;
			}
			if (projectile.ai[1] != -1f)
			{
				projectile.scale = ((float)(num954 + num953) - projectile.ai[1]) * num952 / (float)(num953 + num954);
				projectile.width = (int)((float)num951 * projectile.scale);
				projectile.height = (int)((float)num950 * projectile.scale);
			}
			if (projectile.ai[0] == 1f && projectile.ai[1] > 0f && projectile.owner == Main.myPlayer)
			{
				projectile.netUpdate = true;
				Vector2 center21 = projectile.Center;
				center21.Y -= (float)num950 * projectile.scale / 2f;
				float num947 = ((float)(num954 + num953) - projectile.ai[1] + 1f) * num952 / (float)(num953 + num954);
				center21.Y -= (float)num950 * num947 / 2f;
				center21.Y += 2f;
				Projectile.NewProjectile(center21.X, center21.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("SharknadoRiftProj2"), projectile.damage, projectile.knockBack, projectile.owner, 5f, projectile.ai[1] - 1f);
			}
			if (!Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
			{
				projectile.alpha -= 30;
				if (projectile.alpha < 60)
				{
					projectile.alpha = 60;
				}
				if (projectile.type == 386 && projectile.alpha < 100)
				{
					projectile.alpha = 100;
				}
			}
			else
			{
				projectile.alpha += 30;
				if (projectile.alpha > 150)
				{
					projectile.alpha = 150;
				}
			}
			if (projectile.ai[0] > 0f)
			{
				projectile.ai[0] -= 1f;
			}
			if (projectile.ai[0] <= 0f)
			{
				float num942 = (float)Math.PI / 30f;
				float num941 = (float)projectile.width / 5f;
				if (projectile.type == 386)
				{
					num941 *= 2f;
				}
				float num940 = (float)(Math.Cos((double)num942 * (0.0 - (double)projectile.ai[0])) - 0.5) * num941;
				projectile.position.X -= num940 * (0f - (float)projectile.direction);
				projectile.ai[0] -= 1f;
				num940 = (float)(Math.Cos((double)num942 * (0.0 - (double)projectile.ai[0])) - 0.5) * num941;
				projectile.position.X += num940 * (0f - (float)projectile.direction);
			}
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 20; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 212, projectile.direction * 2, 0f, 100, default(Color), 1.4f);
				Main.dust[dust].color = Color.CornflowerBlue;
				Main.dust[dust].color = Color.Lerp(Main.dust[dust].color, Color.White, 0.3f);
				Main.dust[dust].noGravity = true;
			}
			base.Kill(timeLeft);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Wet, 600, false);
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
