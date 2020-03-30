using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class TopazRift : BaseRiftProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projType = mod.ProjectileType("TopazRiftBolt");
			fireDelay = 37;
			fireVel = 13f;
		}
	}
}
