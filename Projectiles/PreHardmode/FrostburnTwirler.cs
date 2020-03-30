using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class FrostburnTwirler : TorchTwirler
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			twirlerDust = 135;
			dustR = 1f;
			dustG = 0.7f;
			dustB = 0.85f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(BuffID.Frostburn, 180, false);
			}
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
