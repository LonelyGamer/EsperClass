using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class DemoniteCanister : BaseCanister
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 12;
			projectile.height = 32;
			releaseRate = 12;
			projType = mod.ProjectileType("DemoniteCanisterProj");
			pourSpeed = 8f;
		}
	}
}
