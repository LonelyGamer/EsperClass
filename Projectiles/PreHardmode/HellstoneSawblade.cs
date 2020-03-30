using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class HellstoneSawblade : BaseSawbladeProj
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sawflame");
		}

		public override void PostAI()
		{
			if (Main.rand.Next(3) == 0)
			{
				Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), projectile.light, projectile.light *= 0.8f, projectile.light *= 0.6f);
				int num130 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.8f);
				Dust dust3 = Main.dust[num130];
				dust3.velocity += projectile.velocity * 0.2f;
				Main.dust[num130].noGravity = true;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
				target.AddBuff(BuffID.OnFire, 180, false);
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
