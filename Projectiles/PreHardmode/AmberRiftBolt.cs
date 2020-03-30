using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class AmberRiftBolt : AmethystRiftBolt
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_597";
			}
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 10;
			projectile.height = 10;
			projectile.alpha = 255;
			projectile.penetrate = 3;
			projectile.localNPCHitCooldown = -1;
			projectile.usesLocalNPCImmunity = true;
			dustType = 262;
		}
	}
}
