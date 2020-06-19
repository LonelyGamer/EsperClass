using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class DungeonCanister : BaseCanister
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 26;
			projectile.height = 32;
			releaseRate = 10;
			projType = mod.ProjectileType("DungeonCanisterProj");
			pourSpeed = 10f;
		}
	}
}
