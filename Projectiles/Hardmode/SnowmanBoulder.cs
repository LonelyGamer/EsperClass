using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class SnowmanBoulder : BaseBoulderProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 34;
			projectile.height = 34;
			projectile.penetrate = 20;
			maxVel = 16f;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item51, projectile.position);
			for (int i = 0; i < 10; i++)
			{
					int num726 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 76);
					Main.dust[num726].noGravity = true;
					Dust dust24 = Main.dust[num726];
					dust24.velocity -= projectile.oldVelocity * 0.25f;
			}
			base.Kill(timeLeft);
		}
	}
}
