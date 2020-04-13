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
    public class YellowTKRocket : RedTKRocket
    {
		public override void ExplosiveEffect()
		{
			for (int num434 = 0; num434 < 400; num434++)
			{
				int num433 = 133;
				float num432 = 16f;
				if (num434 > 100)
				{
					num432 = 11f;
				}
				if (num434 > 100)
				{
					num433 = 134;
				}
				if (num434 > 200)
				{
					num432 = 8f;
				}
				if (num434 > 200)
				{
					num433 = 133;
				}
				if (num434 > 300)
				{
					num432 = 5f;
				}
				if (num434 > 300)
				{
					num433 = 134;
				}
				int num430 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 6, 6, num433, 0f, 0f, 100);
				float num429 = Main.dust[num430].velocity.X;
				float num428 = Main.dust[num430].velocity.Y;
				if (num429 == 0f && num428 == 0f)
				{
					num429 = 1f;
				}
				float num427 = (float)Math.Sqrt(num429 * num429 + num428 * num428);
				num427 = num432 / num427;
				if (num434 > 300)
				{
					num429 = num429 * num427 * 0.7f;
					num428 *= num427;
				}
				else if (num434 > 200)
				{
					num429 *= num427;
					num428 = num428 * num427 * 0.7f;
				}
				else if (num434 > 100)
				{
					num429 = num429 * num427 * 0.7f;
					num428 *= num427;
				}
				else
				{
					num429 *= num427;
					num428 = num428 * num427 * 0.7f;
				}
				Dust dust24 = Main.dust[num430];
				dust24.velocity *= 0.5f;
				Dust expr_15CE6_cp_0 = Main.dust[num430];
				expr_15CE6_cp_0.velocity.X = expr_15CE6_cp_0.velocity.X + num429;
				Dust expr_15D05_cp_0 = Main.dust[num430];
				expr_15D05_cp_0.velocity.Y = expr_15D05_cp_0.velocity.Y + num428;
				if (Main.rand.Next(3) != 0)
				{
					Main.dust[num430].scale = 1.3f;
					Main.dust[num430].noGravity = true;
				}
			}
		}
    }
}
