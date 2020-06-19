using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class OrichalcumSawblade : BaseSawbladeProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 34;
			projectile.height = 34;
			maxVel = 20f;
		}
	}
}
