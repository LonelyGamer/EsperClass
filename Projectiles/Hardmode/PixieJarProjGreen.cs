using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class PixieJarProjGreen : PixieJarProjBlue
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			dustNum = 74;
			lightR = 0.45f;
			lightG = 1f;
			lightB = 0.75f;
		}
	}
}
