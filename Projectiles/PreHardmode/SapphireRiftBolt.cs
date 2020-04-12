using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class SapphireRiftBolt : BaseRiftBolt
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_123";
			}
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 10;
			projectile.height = 10;
			projectile.alpha = 255;
			projectile.penetrate = 1;
			dustType = 88;
		}
	}
}
