using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode.CrossMod
{
	public class ApprenticeSawblade : BaseSawbladeProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			maxVel = 12f;
		}

		public override void PostAI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			Dust dust;
			Vector2 position = projectile.position + projectile.velocity;
			dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 88, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
			dust.noGravity = true;
		}
	}
}
