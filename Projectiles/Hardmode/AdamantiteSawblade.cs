using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class AdamantiteSawblade : BaseSawbladeProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 36;
			projectile.height = 36;
			maxVel = 20f;
		}
	}
}
