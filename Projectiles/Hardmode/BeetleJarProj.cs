using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class BeetleJarProj : BaseJarProj
	{
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 22;
			projectile.height = 18;
			projectile.aiStyle = 36;
			projectile.penetrate = 10;
			Main.projFrames[projectile.type] = 4;
			chaseLiquid = true;
		}
	}
}
