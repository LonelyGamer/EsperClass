using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class SuperSpittingSandfishProj : ECProjectile
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
			projectile.penetrate = 5;
			projectile.localNPCHitCooldown = -1;
			projectile.usesLocalNPCImmunity = true;
			projectile.ignoreWater = true;
		}

		public override void AI()
		{
			ExtraAI();
		}
	}
}
