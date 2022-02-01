using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class Pompakin : BaseBoulderProj
	{
		int fireTimer = 0;

		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 40;
			projectile.height = 40;
			projectile.penetrate = 20;
			maxVel = 20f;
		}

		public override void PostAI()
		{
			base.PostAI();
			if (!held && Math.Abs(projectile.velocity.X) > 3f && Math.Abs(projectile.velocity.Y) < 0.5f)
			{
				fireTimer += 1;
				if (fireTimer >= 3)
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
						Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.8f);
						Main.PlaySound(SoundID.Item13, projectile.position);
						Projectile.NewProjectile(vector.X, vector.Y, 0, 0, projType, (int)(projectile.damage / 3), projectile.knockBack / 5f, Main.player[projectile.owner].whoAmI);
					}
				}
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			touched = true;
			if (held)
				return true;
			else
			{
				if ((projectile.velocity.X != oldVelocity.X && (oldVelocity.X < -3f || oldVelocity.X > 3f)) || (projectile.velocity.Y != oldVelocity.Y && (oldVelocity.Y < -3f || oldVelocity.Y > 3f)))
				{
					Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
					Main.PlaySound(0, (int)projectile.Center.X, (int)projectile.Center.Y, 1, 1f, 0f);
				}
				return false;
			}
		}
	}
}
