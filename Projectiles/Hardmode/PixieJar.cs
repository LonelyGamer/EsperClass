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

		public override void JarShake()
		{
			int randomEffect = Main.rand.Next(3);
			int dustNum = 56;
			float lightR = 0.45f;
			float lightG = 0.75f;
			float lightB = 1f;
			switch (randomEffect)
			{
				case 0:
					break;
				case 1:
					dustNum = 74;
					lightR = 0.45f;
					lightG = 1f;
					lightB = 0.75f;
					break;
				case 2:
					dustNum = 73;
					lightR = 1f;
					lightG = 0.45f;
					lightB = 0.75f;
					break;
			}
			Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), lightR, lightG, lightB);
			int num445 = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustNum, 0f, 0f, 200, default(Color), 0.8f);
			Dust dust81 = Main.dust[num445];
			dust81.velocity *= 0.3f;
			base.JarShake();
		}
    }
}
