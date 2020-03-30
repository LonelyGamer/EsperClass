using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class CrimtaneCanisterProj : BaseCanisterProj
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Canister Liquid");
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			dustNum = 5;
			dustColor = new Color(255, 255, 255, 100);
		}
	}
}
