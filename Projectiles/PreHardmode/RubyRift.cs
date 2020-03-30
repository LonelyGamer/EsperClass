using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class RubyRift : BaseRiftProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projType = mod.ProjectileType("RubyRiftBolt");
			fireDelay = 27;
			fireVel = 18f;
		}
	}
}
