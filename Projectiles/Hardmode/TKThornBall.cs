using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class TKThornBall : BaseBoulderProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 30;
			projectile.height = 30;
			projectile.penetrate = 20;
			maxVel = 20f;
		}
	}
}
