using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class BatJarProj : BaseJarProj
	{
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 16;
			projectile.height = 10;
			projectile.aiStyle = 36;
			projectile.penetrate = 3;
			Main.projFrames[projectile.type] = 3;
		}

		public override void ExtraAI()
		{
			if (projectile.wet)
			{
				projectile.Kill();
			}
			projectile.frameCounter++;
			if (projectile.frameCounter > 7)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame > 2)
				{
					projectile.frame = 0;
				}
			}
			base.ExtraAI();
		}
	}
}
