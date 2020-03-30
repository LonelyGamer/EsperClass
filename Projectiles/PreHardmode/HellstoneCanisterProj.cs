using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class HellstoneCanisterProj : BaseCanisterProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.penetrate = 5;
			dustNum = 6;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 180, false);
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
