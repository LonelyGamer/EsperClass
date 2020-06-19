using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class PinkSlimyCanister : BaseCanister
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projType = mod.ProjectileType("PinkSlimyCanisterProj");
		}
	}
}
