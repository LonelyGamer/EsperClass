using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode.CrossMod
{
	public class NoviceSawblade : BaseSawbladeProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 24;
			projectile.height = 24;
			maxVel = 12f;
		}

		public override void PostAI()
		{
			Dust dust;
			Vector2 position = projectile.position + projectile.velocity;
			dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 91, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
			dust.noGravity = true;
		}
	}
}
