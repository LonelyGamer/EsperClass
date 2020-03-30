using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class DemonTwirler : TorchTwirler
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			twirlerDust = 65;
			dustR = 0.5f;
			dustG = 0.3f;
			dustB = 1f;
		}

		public override void PostAI()
		{
			if (projectile.velocity.X != 0)
				dir = Math.Sign(projectile.velocity.X);
			projectile.rotation -= dir * 6;
			if (!projectile.wet && !projectile.lavaWet)
			{
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, twirlerDust, 0f, 0f, 100, default(Color), 1f);
				Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), dustR * Main.demonTorch + 1f * (1f - Main.demonTorch), dustG, dustB * Main.demonTorch + 0.5f * (1f - Main.demonTorch));
			}
		}
	}
}
