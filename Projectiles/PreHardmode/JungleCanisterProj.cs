using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class JungleCanisterProj : BaseCanisterProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.penetrate = 3;
			dustNum = 256;
			dustColor = new Color(255, 255, 255, 100);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Poisoned, 180, false);
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
