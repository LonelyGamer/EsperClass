using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class DemoniteCanisterProj : BaseCanisterProj
	{
		public override void SetDefaults()
		{
			dustNum = 98;
			dustColor = new Color(255, 255, 255, 100);
			base.SetDefaults();
		}
	}
}
