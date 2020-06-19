using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class CobaltSawblade : BaseSawbladeProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			maxVel = 20f;
		}
	}
}
