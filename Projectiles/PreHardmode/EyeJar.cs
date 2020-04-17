using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class EyeJar : BaseJar
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projType = mod.ProjectileType("EyeJarProj");
		}
	}
}
