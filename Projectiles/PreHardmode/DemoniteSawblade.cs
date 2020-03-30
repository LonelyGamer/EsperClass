using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class DemoniteSawblade : BaseSawbladeProj
	{
		public override void PostAI()
		{
			if (Main.rand.Next(3) == 0)
			{
				int num130 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 14, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.8f);
				Dust dust3 = Main.dust[num130];
				dust3.velocity *= 1.3f;
				dust3 = Main.dust[num130];
				dust3.velocity += projectile.velocity;
				Main.dust[num130].noGravity = true;
			}
		}
	}
}
