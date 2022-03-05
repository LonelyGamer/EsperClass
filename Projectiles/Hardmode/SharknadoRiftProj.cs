using System;
using Microsoft.Xna.Framework;
using Terraria;

namespace EsperClass.Projectiles.Hardmode
{
    public class SharknadoRiftProj : ECProjectile
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_408";
			}
		}

		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 2;
		}

		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.friendly = true;
			projectile.ignoreWater = true;
		}

		public override void AI()
		{
			ExtraAI();
			projectile.frameCounter++;
			if (projectile.frameCounter > 3)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame > 1)
				{
					projectile.frame = 0;
				}
			}
			projectile.ai[0]++;
			if (projectile.ai[0] >= 45f)
			{
				projectile.ai[0] = 45f;
				projectile.velocity.Y = projectile.velocity.Y + 0.05f;
			}
			projectile.spriteDirection = projectile.direction;
			projectile.rotation = projectile.velocity.ToRotation();
			if (projectile.direction == -1)
			{
				projectile.rotation += (float)Math.PI;
			}
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			damage *= 2;
			base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 15; i++)
			{
				int num891 = Dust.NewDust(projectile.Center - Vector2.One * 10f, 50, 50, 5, 0f, -2f);
				Dust dust24 = Main.dust[num891];
				dust24.velocity /= 2f;
			}
			int num895 = 10;
			int num894 = Gore.NewGore(projectile.Center, projectile.velocity * 0.8f, 584);
			Main.gore[num894].timeLeft /= num895;
			num894 = Gore.NewGore(projectile.Center, projectile.velocity * 0.9f, 585);
			Main.gore[num894].timeLeft /= num895;
			num894 = Gore.NewGore(projectile.Center, projectile.velocity * 1f, 586);
			Main.gore[num894].timeLeft /= num895;
			if (projectile.owner == Main.myPlayer)
			{
				if (projectile.ai[1] < 1f)
				{
					int proj = Projectile.NewProjectile(projectile.Center.X - 30, projectile.Center.Y + 42, (0f - (float)projectile.direction) * 0.01f, 0f, mod.ProjectileType("SharknadoRiftProj2"), projectile.damage, 4f, projectile.owner, 16f, 15f);
					Main.projectile[proj].netUpdate = true;
				}
			}
			base.Kill(timeLeft);
		}
	}
}
