using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class HellstoneCanister : BaseCanister
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 26;
			projectile.height = 38;
			projType = mod.ProjectileType("HellstoneCanisterProj");
			pourSpeed = 4f;
		}
	}
}
