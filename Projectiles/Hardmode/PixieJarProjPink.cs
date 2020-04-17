using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class PixieJarProjPink : PixieJarProjBlue
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			dustNum = 73;
			lightR = 1f;
			lightG = 0.45f;
			lightB = 0.75f;
		}
	}
}
