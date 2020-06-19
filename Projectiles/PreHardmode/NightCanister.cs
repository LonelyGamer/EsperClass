using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class NightCanister : BaseCanister
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 22;
			projectile.height = 38;
			releaseRate = 12;
			projType = mod.ProjectileType("NightCanisterProj");
			pourSpeed = 8f;
		}
	}
}
