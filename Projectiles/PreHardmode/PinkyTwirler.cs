using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class PinkyTwirler : TorchTwirler
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			twirlerDust = 242;
			dustR = 1f;
			dustG = 0f;
			dustB = 1f;
		}
	}
}
