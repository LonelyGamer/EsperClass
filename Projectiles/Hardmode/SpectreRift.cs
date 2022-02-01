using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class SpectreRift : BaseRiftProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 46;
			projectile.height = 56;
			projType = mod.ProjectileType("SpectreRiftBolt");
			fireDelay = 24;
			fireVel = 24f;
			ignoreLoS = true;
			Main.projFrames[projectile.type] = 4;
		}

		public override void ExtraAI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 3)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame > 3)
				{
					projectile.frame = 0;
				}
			}
			base.ExtraAI();
		}
	}
}
