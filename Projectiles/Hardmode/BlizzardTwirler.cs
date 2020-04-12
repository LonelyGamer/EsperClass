using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class BlizzardTwirler : BaseTwirlerProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			twirlerDust = 135;
			dustR = 1f;
			dustG = 0.7f;
			dustB = 0.85f;
		}

		public override void OnHitNPC(NPC npc, int damage, float knockback, bool crit)
		{
			npc.AddBuff(mod.BuffType("NPCChill"), 30, false);
			if (Main.rand.Next(4) == 0)
			{
				npc.AddBuff(BuffID.Frostburn, 300, false);
			}
			base.OnHitNPC(npc, damage, knockback, crit);
		}
	}
}
