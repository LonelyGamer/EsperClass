using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PostMoonLord
{
	public class EldritchEyeJar : BaseJar
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projType = mod.ProjectileType("EldritchEyeJarProj");
			releaseDelay = 30;
			maxVel = 16f;
			projectile.ignoreWater = true;
		}
	}
}
