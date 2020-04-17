using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class CursedFlameOrbitProj : ECProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}

		public override void AI()
		{
			ExtraAI();
			projectile.timeLeft++;
			if (Main.rand.Next(2) == 0)
			{
				int num4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 75, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 2.5f);
				Main.dust[num4].noGravity = true;
				Main.dust[num4].velocity *= 0.7f;
				Dust dust2 = Main.dust[num4];
				dust2.velocity.Y = dust2.velocity.Y - 0.5f;
			}
			if (Main.projectile[(int)projectile.ai[0]].active)
			{
				Vector2 vector = (Main.projectile[(int)projectile.ai[0]].Center - projectile.Center).SafeNormalize(Vector2.UnitY);
				projectile.rotation = vector.ToRotation() + 0.78f;
			 	projectile.ai[1] += 8f * Main.projectile[(int)projectile.ai[0]].spriteDirection;
				float vX = 64 * (float)Math.Cos(projectile.ai[1] / 180 * Math.PI);
				float vY = 64 * (float)Math.Sin(projectile.ai[1] / 180 * Math.PI);
				projectile.position = Main.projectile[(int)projectile.ai[0]].Center - projectile.Size / 2f;
				projectile.velocity.X = vX;
				projectile.velocity.Y = vY;
			}
			else
			{
				projectile.Kill();
				return;
			}
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (projectile.velocity.X != 0)
				hitDirection = Math.Sign(projectile.velocity.X);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(BuffID.CursedInferno, 180, false);
			}
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
