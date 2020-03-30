using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class NightCanisterProj : BaseCanisterProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.penetrate = 5;
			dustNum = 27;
		}
	}
}
