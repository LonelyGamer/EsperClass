using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class RainbowTwirler : CursedTwirler
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			twirlerDust = 66;
		}

		public override void PostAI()
		{
			if (projectile.velocity.X != 0)
				dir = Math.Sign(projectile.velocity.X);
			projectile.rotation -= dir * 6;
			if (!projectile.wet && !projectile.lavaWet)
			{
				int rainbowDust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, twirlerDust, 0f, 0f, 100, default(Color), 1f);
				Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), (float)Main.DiscoR / 255f, (float)Main.DiscoG / 255f, (float)Main.DiscoB / 255f);
				Main.dust[rainbowDust].color = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
				Main.dust[rainbowDust].noGravity = true;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(BuffID.OnFire, 180, false);
			}
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(BuffID.Frostburn, 180, false);
			}
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
