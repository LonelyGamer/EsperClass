using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class DiamondRiftBolt : AmethystRiftBolt
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_126";
			}
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 10;
			projectile.height = 10;
			projectile.alpha = 255;
			projectile.penetrate = 2;
			projectile.localNPCHitCooldown = -1;
			projectile.usesLocalNPCImmunity = true;
			dustType = 91;
		}
	}
}
