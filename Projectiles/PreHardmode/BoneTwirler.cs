using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class BoneTwirler : TorchTwirler
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			twirlerDust = 234;
			dustR = 0.95f;
			dustG = 0.65f;
			dustB = 1.3f;
		}
	}
}
