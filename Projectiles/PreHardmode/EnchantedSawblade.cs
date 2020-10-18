using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class EnchantedSawblade : BaseSawbladeProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.light = 0.4f;
			maxVel = 20f;
		}

		public override void PostAI()
		{
			if (Main.rand.Next(2) == 0)
			{
				int num115;
				switch (Main.rand.Next(3))
				{
				case 0:
					num115 = 15;
					break;
				case 1:
					num115 = 57;
					break;
				default:
					num115 = 58;
					break;
				}
				Dust.NewDust(projectile.position, projectile.width, projectile.height, num115, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 150, default(Color), 0.7f);
			}
			base.PostAI();
		}
	}
}
