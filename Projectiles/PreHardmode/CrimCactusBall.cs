using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class CrimCactusBall : CactusBall
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 22;
			projectile.height = 22;
		}
	}
}
