using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class WaspJar : BaseJar
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projType = mod.ProjectileType("WaspJarProj");
		}
	}
}
