using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class GreekFireProj2 : GreekFireProj1
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_327";
			}
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 12;
			projectile.height = 14;
		}
	}
}
