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
    public class GreenTKRocket : RedTKRocket
    {
		public override void ExplosiveEffect()
		{
			for (int num470 = 0; num470 < 400; num470++)
			{
				float num469 = 2f * ((float)num470 / 100f);
				if (num470 > 100)
				{
					num469 = 10f;
				}
				if (num470 > 250)
				{
					num469 = 13f;
				}
				int num468 = 131;
				int num466 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 6, 6, num468, 0f, 0f, 100);
				float num465 = Main.dust[num466].velocity.X;
				float num464 = Main.dust[num466].velocity.Y;
				if (num465 == 0f && num464 == 0f)
				{
					num465 = 1f;
				}
				float num463 = (float)Math.Sqrt(num465 * num465 + num464 * num464);
				num463 = num469 / num463;
				if (num470 <= 200)
				{
					num465 *= num463;
					num464 *= num463;
				}
				else
				{
					num465 = num465 * num463 * 1.25f;
					num464 = num464 * num463 * 0.75f;
				}
				Dust dust24 = Main.dust[num466];
				dust24.velocity *= 0.5f;
				Dust expr_154F1_cp_0 = Main.dust[num466];
				expr_154F1_cp_0.velocity.X = expr_154F1_cp_0.velocity.X + num465;
				Dust expr_15510_cp_0 = Main.dust[num466];
				expr_15510_cp_0.velocity.Y = expr_15510_cp_0.velocity.Y + num464;
				if (num470 > 100)
				{
					Main.dust[num466].scale = 1.3f;
					Main.dust[num466].noGravity = true;
				}
			}
		}
    }
}
