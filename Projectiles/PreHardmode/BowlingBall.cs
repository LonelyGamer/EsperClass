using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class BowlingBall : BaseBoulderProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 30;
			projectile.height = 30;
			projectile.penetrate = 6;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (crit && projectile.ai[1] == 0f)
			{
				Main.PlaySound(SoundLoader.customSoundType, projectile.position, mod.GetSoundSlot(SoundType.Custom, "Sounds/BowlingStrike"));
				projectile.ai[1]++;

			}
			base.OnHitNPC(target, damage, knockback, crit);
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
			for (int i = 0; i < 30; i++)
			{
				int num472 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 1, 0f, 0f, 0, default(Color), 1f);
				if (Main.rand.Next(2) == 0)
				{
					Dust dust = Main.dust[num472];
					dust.scale *= 1.4f;
				}
				projectile.velocity *= 1.9f;
			}
			/*if (!projectile.noDropItem)
			{
				if (Main.rand.Next(2) == 0)
					Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("BowlingBall"), 1, false, 0, false);
			}*/
			base.Kill(timeLeft);
		}
	}
}
