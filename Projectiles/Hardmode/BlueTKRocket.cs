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
    public class BlueTKRocket : RedTKRocket
    {
		public override void ExplosiveEffect()
		{
			Vector2 vector10 = ((float)Main.rand.NextDouble() * ((float)Math.PI * 2f)).ToRotationVector2();
			float num459 = Main.rand.Next(5, 9);
			float num458 = Main.rand.Next(12, 17);
			float value18 = Main.rand.Next(3, 7);
			float num457 = 20f;
			for (float num456 = 0f; num456 < num459; num456 += 1f)
			{
				for (int num439 = 0; num439 < 2; num439++)
				{
					Vector2 value15 = vector10.RotatedBy(((num439 == 0) ? 1f : (-1f)) * ((float)Math.PI * 2f) / (num459 * 2f));
					for (float num437 = 0f; num437 < num457; num437 += 1f)
					{
						Vector2 value14 = Vector2.Lerp(vector10, value15, num437 / num457);
						float scaleFactor16 = MathHelper.Lerp(num458, value18, num437 / num457);
						int num435 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 6, 6, 133, 0f, 0f, 100, default(Color), 1.3f);
						Dust dust24 = Main.dust[num435];
						dust24.velocity *= 0.1f;
						Main.dust[num435].noGravity = true;
						dust24 = Main.dust[num435];
						dust24.velocity += value14 * scaleFactor16;
					}
				}
				vector10 = vector10.RotatedBy((float)Math.PI * 2f / num459);
			}
			for (float num455 = 0f; num455 < num459; num455 += 1f)
			{
				for (int num443 = 0; num443 < 2; num443++)
				{
					Vector2 value17 = vector10.RotatedBy(((num443 == 0) ? 1f : (-1f)) * ((float)Math.PI * 2f) / (num459 * 2f));
					for (float num441 = 0f; num441 < num457; num441 += 1f)
					{
						Vector2 value16 = Vector2.Lerp(vector10, value17, num441 / num457);
						float scaleFactor17 = MathHelper.Lerp(num458, value18, num441 / num457) / 2f;
						int num440 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 6, 6, 133, 0f, 0f, 100, default(Color), 1.3f);
						Dust dust24 = Main.dust[num440];
						dust24.velocity *= 0.1f;
						Main.dust[num440].noGravity = true;
						dust24 = Main.dust[num440];
						dust24.velocity += value16 * scaleFactor17;
					}
				}
				vector10 = vector10.RotatedBy((float)Math.PI * 2f / num459);
			}
			for (int num454 = 0; num454 < 100; num454++)
			{
				float num453 = num458;
				int num452 = 132;
				int num450 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 6, 6, num452, 0f, 0f, 100);
				float num449 = Main.dust[num450].velocity.X;
				float num448 = Main.dust[num450].velocity.Y;
				if (num449 == 0f && num448 == 0f)
				{
					num449 = 1f;
				}
				float num447 = (float)Math.Sqrt(num449 * num449 + num448 * num448);
				num447 = num453 / num447;
				num449 *= num447;
				num448 *= num447;
				Dust dust24 = Main.dust[num450];
				dust24.velocity *= 0.5f;
				Dust expr_15A4B_cp_0 = Main.dust[num450];
				expr_15A4B_cp_0.velocity.X = expr_15A4B_cp_0.velocity.X + num449;
				Dust expr_15A6A_cp_0 = Main.dust[num450];
				expr_15A6A_cp_0.velocity.Y = expr_15A6A_cp_0.velocity.Y + num448;
				Main.dust[num450].scale = 1.3f;
				Main.dust[num450].noGravity = true;
			}
		}
    }
}
