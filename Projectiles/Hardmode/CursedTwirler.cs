using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class CursedTwirler : BaseTwirlerProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			twirlerDust = 75;
			dustR = 0.7f;
			dustG = 0.85f;
			dustB = 1f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(BuffID.CursedInferno, 300, false);
			}
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
