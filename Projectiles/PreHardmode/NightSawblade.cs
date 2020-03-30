using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class NightSawblade : BaseSawbladeProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			maxVel = 20f;
		}

		public override void PostAI()
		{
			if (Main.rand.Next(3) == 0)
			{
				int num130 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 27, 0f, 0f, 100, default(Color), 1.8f);
				Dust dust3 = Main.dust[num130];
				dust3.velocity += projectile.velocity * 0.2f;
				Main.dust[num130].noGravity = true;
			}
		}
	}
}
