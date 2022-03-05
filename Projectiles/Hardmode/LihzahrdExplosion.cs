using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class LihzahrdExplosion : ECProjectile
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
			projectile.width = 384;
			projectile.height = 384;
            projectile.alpha = 255;
			projectile.friendly = true;
			projectile.hide = true;
			projectile.penetrate = -1;
			projectile.localNPCHitCooldown = -1;
			projectile.usesLocalNPCImmunity = true;
			projectile.ignoreWater = true;
            projectile.tileCollide = false;
			projectile.timeLeft = 5;
			ignoreLihzahrdPower = true;
		}

		public override void AI()
		{
			if (projectile.owner == Main.myPlayer && projectile.timeLeft == 5)
			{
				projectile.maxPenetrate = 0;
				projectile.Damage();
			}
			for (int i = 0; i < 20; i++)
			{
				int num103 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 3f * projectile.scale);
				Main.dust[num103].noGravity = true;
			}
		}

		/*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.CursedInferno, 420, false);
		}*/
	}
}
