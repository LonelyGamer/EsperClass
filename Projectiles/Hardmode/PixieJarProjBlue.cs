using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
    public class PixieJarProjBlue : BaseJarProj
	{
		protected int dustNum = 56;
		protected float lightR = 0.45f;
		protected float lightG = 0.75f;
		protected float lightB = 1f;

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 14;
			projectile.height = 12;
			projectile.penetrate = 5;
			projectile.timeLeft = 600;
			Main.projFrames[projectile.type] = 2;
		}

		public override void ExtraAI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 7)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame > 1)
				{
					projectile.frame = 0;
				}
			}
			Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), lightR, lightG, lightB);
			int num445 = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustNum, 0f, 0f, 200, default(Color), 0.8f);
			Dust dust81 = Main.dust[num445];
			dust81.velocity *= 0.3f;
			base.ExtraAI();
		}
	}
}

