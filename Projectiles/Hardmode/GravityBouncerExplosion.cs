using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class GravityBouncerExplosion : ECProjectile
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_0";
			}
		}

		public override void SetDefaults()
		{
			projectile.width = 256;
			projectile.height = 256;
            projectile.alpha = 255;
			projectile.friendly = true;
			projectile.hide = true;
			projectile.penetrate = 1;
			projectile.ignoreWater = true;
            projectile.tileCollide = false;
			projectile.timeLeft = 5;
		}

		public override void AI()
		{
			/*if (projectile.owner == Main.myPlayer && projectile.timeLeft == 5)
			{
				projectile.maxPenetrate = -1;
				projectile.penetrate = -1;
				projectile.Damage();
			}*/
			/*for (int i = -10; i < 10; i++)
			{
				//if (i != 0)
				{
					int dust = Dust.NewDust(new Vector2(projectile.position.X + (i * 2), projectile.position.Y), 20, 20, 162, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 3f * projectile.scale);
					Main.dust[dust].noGravity = true;
					dust = Dust.NewDust(new Vector2(projectile.position.X + (i * 2), projectile.position.Y + (i * 5)), 20, 20, 162, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 3f * projectile.scale);
					Main.dust[dust].noGravity = true;
				}
			}*/
		}
	}
}
