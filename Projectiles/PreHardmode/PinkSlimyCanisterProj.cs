using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class PinkSlimyCanisterProj : BaseCanisterProj
	{
		public override void SetDefaults()
		{
			dustColor = new Color(250, 30, 90, 90);
			base.SetDefaults();
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Slimed, 300, false);
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
