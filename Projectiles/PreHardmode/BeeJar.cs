using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class BeeJar : BaseJar
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 20;
			projectile.height = 28;
		}

		public override void ExtraAI()
		{
			projType = Main.player[projectile.owner].beeType();
		}
	}
}
