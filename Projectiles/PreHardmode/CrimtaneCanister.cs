using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class CrimtaneCanister : BaseCanister
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 20;
			projectile.height = 34;
			releaseRate = 15;
			projType = mod.ProjectileType("CrimtaneCanisterProj");
			pourSpeed = 4f;
		}
	}
}
