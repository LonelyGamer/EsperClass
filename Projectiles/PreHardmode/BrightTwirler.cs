using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class BrightTwirler : TorchTwirler
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			twirlerDust = 156;
			dustR *= 0.75f;
			dustG *= 1.3499999f;
			dustB *= 1.5f;
		}
	}
}
