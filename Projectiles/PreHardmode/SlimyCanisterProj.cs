using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class SlimyCanisterProj : BaseCanisterProj
	{
		public override void SetDefaults()
		{
			dustColor = new Color(0, 80, 255, 100);
			base.SetDefaults();
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Slimed, 300, false);
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
