using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class IchorCanister : BaseCanister
	{
		public override void SetDefaults()
		{
            base.SetDefaults();
			projectile.width = 18;
			projectile.height = 40;
			releaseRate = 12;
			projType = mod.ProjectileType("IchorCanisterProj");
			pourSpeed = 8f;
		}
	}
}
