using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class TerraSawblade : BaseSawbladeProj
	{
		bool doOnce = false;
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.localNPCHitCooldown = 5;
			projectile.usesLocalNPCImmunity = true;
			maxVel = 24f;
		}

		/*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 5;
		}*/

        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            hitbox = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, 42, 42);
		}

		public override void PostAI()
		{
			int num1002 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 8, 8, 107, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.25f);
			Dust dust81 = Main.dust[num1002];
			dust81.velocity *= -0.25f;
			num1002 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 8, 8, 107, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.25f);
			dust81 = Main.dust[num1002];
			dust81.velocity *= -0.25f;
			dust81 = Main.dust[num1002];
			dust81.position -= projectile.velocity * 0.5f;
			if (!doOnce && projectile.owner == Main.myPlayer)
			{
				int projCheck = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("TerraSawbladeProj"), (int)(projectile.damage), projectile.knockBack, Main.player[projectile.owner].whoAmI, projectile.whoAmI);
				Main.projectile[projCheck].ai[1] = 90;
				Main.projectile[projCheck].spriteDirection = Math.Sign(projectile.velocity.X);
				if (Main.projectile[projCheck].spriteDirection == 0)
					Main.projectile[projCheck].spriteDirection = Main.player[projectile.owner].direction;
				doOnce = true;
			}
			base.PostAI();
		}
	}
}
