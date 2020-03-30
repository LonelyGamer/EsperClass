using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode.CrossMod
{
	public class SoilSawblade : BaseSawbladeProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 22;
			projectile.height = 22;
		}

		public override void PostAI()
		{
			if (Main.rand.Next(8) == 0)
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 0);
		}
	}
}
