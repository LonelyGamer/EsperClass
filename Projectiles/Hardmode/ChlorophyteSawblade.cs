using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class ChlorophyteSawblade : BaseSawbladeProj
	{
		int fireTimer = 0;
		public override void SetDefaults()
		{
			base.SetDefaults();
			maxVel = 24f;
			projectile.width = 26;
			projectile.height = 26;
		}

        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            hitbox = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, 42, 38);
		}

		public override void PostAI()
		{
			fireTimer++;
			if (fireTimer >= 30)
			{
				fireTimer = 0;
				if (projectile.owner == Main.myPlayer)
				{
					Projectile.NewProjectile(projectile.Center.X + projectile.velocity.X, projectile.Center.Y + projectile.velocity.Y, 0, 0, ProjectileID.SporeCloud, (int)(projectile.damage), projectile.knockBack, Main.player[projectile.owner].whoAmI);
				}
			}
			base.PostAI();
		}
	}
}
