using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class InfernoSpitProj2 : ECProjectile
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_296";
			}
		}

		public override void SetDefaults()
		{
			projectile.width = 150;
			projectile.height = 150;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 180;
		}

		public override void AI()
		{
			float num1178 = 18f;
			for (int num1177 = 0; (float)num1177 < num1178; num1177++)
			{
				float num1176 = Main.rand.Next(-10, 11);
				float num1175 = Main.rand.Next(-10, 11);
				float num1174 = Main.rand.Next(3, 9);
				float num1173 = (float)Math.Sqrt(num1176 * num1176 + num1175 * num1175);
				num1173 = num1174 / num1173;
				num1176 *= num1173;
				num1175 *= num1173;
				int num1168 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 174, 0f, 0f, 100, default(Color), 1.5f);
				Main.dust[num1168].noGravity = true;
				Main.dust[num1168].position.X = projectile.Center.X;
				Main.dust[num1168].position.Y = projectile.Center.Y;
				Dust expr_14B37_cp_0 = Main.dust[num1168];
				expr_14B37_cp_0.position.X = expr_14B37_cp_0.position.X + (float)Main.rand.Next(-10, 11);
				Dust expr_14B61_cp_0 = Main.dust[num1168];
				expr_14B61_cp_0.position.Y = expr_14B61_cp_0.position.Y + (float)Main.rand.Next(-10, 11);
				Main.dust[num1168].velocity.X = num1176;
				Main.dust[num1168].velocity.Y = num1175;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 300, false);
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
