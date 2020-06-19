using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class LiquidNitrogenCanister : BaseCanister
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 18;
			projectile.height = 42;
			releaseRate = 15;
			projType = mod.ProjectileType("LiquidNitrogenCanisterProj");
			pourSpeed = 12f;
		}
	}
}
