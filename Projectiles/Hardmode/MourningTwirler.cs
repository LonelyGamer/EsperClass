using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class MourningTwirler : BaseTwirlerProj
	{
		int fireTimer = 0;

		public override void SetDefaults()
		{
			base.SetDefaults();
			twirlerDust = 6;
			dustR = 1f;
			dustG = 0.95f;
			dustB = 0.8f;
		}

		public override void PostAI()
		{
			base.PostAI();
			if (!held)
			{
				return;
			}
			if (projectile.velocity.X != 0)
				projectile.spriteDirection = Math.Sign(projectile.velocity.X);
			fireTimer += 1;
			if (fireTimer >= 6)
			{
				fireTimer = 0;
				int randomSpawn = Main.rand.Next(3);
				int projType = 0;
				switch (randomSpawn)
				{
					case 0:
						projType = mod.ProjectileType("GreekFireProj1");
						break;
					case 1:
						projType = mod.ProjectileType("GreekFireProj2");
						break;
					case 2:
						projType = mod.ProjectileType("GreekFire3Proj");
						break;
				}
				if (projectile.owner == Main.myPlayer)
				{
					Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
					Main.PlaySound(SoundID.Item13, projectile.position);
					Projectile.NewProjectile(vector.X, vector.Y, Main.rand.Next(-8, 9), Main.rand.Next(-4, 3), projType, (int)(projectile.damage), projectile.knockBack, Main.player[projectile.owner].whoAmI);
				}
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 300, false);
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
