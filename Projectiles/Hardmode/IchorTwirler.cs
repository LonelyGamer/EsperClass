using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class IchorTwirler : CursedTwirler
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			twirlerDust = 169;
			dustR = 0.8f;
			dustG = 1.25f;
			dustB = 1.25f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(BuffID.Ichor, 180, false);
			}
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
