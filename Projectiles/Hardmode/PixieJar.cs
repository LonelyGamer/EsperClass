using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
    public class PixieJar : BaseJar
    {
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 20;
			projectile.height = 28;
		}

		public override void ExtraAI()
		{
			int randomSpawn = Main.rand.Next(3);
			switch (randomSpawn)
			{
				case 0:
					projType = mod.ProjectileType("PixieJarProjBlue");
					break;
				case 1:
					projType = mod.ProjectileType("PixieJarProjGreen");
					break;
				case 2:
					projType = mod.ProjectileType("PixieJarProjPink");
					break;
			}
		}
    }
}
