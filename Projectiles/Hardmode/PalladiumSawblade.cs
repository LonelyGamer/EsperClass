using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class PalladiumSawblade : BaseSawbladeProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 26;
			projectile.height = 26;
			maxVel = 20f;
		}
	}
}
