using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class TorchTwirler : BaseTwirlerProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			twirlerDust = 6;
			dustR = 1f;
			dustG = 0.95f;
			dustB = 0.8f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(BuffID.OnFire, 180, false);
			}
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
