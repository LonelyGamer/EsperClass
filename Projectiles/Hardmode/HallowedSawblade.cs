using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class HallowedSawblade : BaseSawbladeProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 24;
			projectile.height = 24;
			maxVel = 20f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 5;
		}

		public override void PostAI()
		{
			if (Main.rand.Next(3) == 0)
			{
				int num819 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 57, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 200, default(Color), 1.2f);
				Dust dust81 = Main.dust[num819];
				dust81.velocity += projectile.velocity * 0.3f;
				dust81 = Main.dust[num819];
				dust81.velocity *= 0.2f;
			}
			if (Main.rand.Next(4) == 0)
			{
				int num827 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 43, 0f, 0f, 254, default(Color), 0.3f);
				Dust dust81 = Main.dust[num827];
				dust81.velocity += projectile.velocity * 0.5f;
				dust81 = Main.dust[num827];
				dust81.velocity *= 0.5f;
			}
		}
	}
}
