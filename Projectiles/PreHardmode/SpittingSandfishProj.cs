using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class SpittingSandfishProj : ECProjectile
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_405";
			}
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 20;
			projectile.height = 20;
			projectile.penetrate = 1;
			projectile.ignoreWater = true;
		}

		public override void AI()
		{
			ExtraAI();
		}
	}
}
