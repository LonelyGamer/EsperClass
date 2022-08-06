using System;
using EsperClass.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Projectiles.Hardmode
{
    public class GravityBouncer : ECProjectile
	{
		int hitCount = 0;
		public override void SetDefaults()
		{
			projectile.width = 34;
			projectile.height = 34;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			maxVel = 13f;
			whizze = false;
			rotate = false;
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 26;
			height = 26;
			return true;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (projectile.localAI[1] == 1)
				return;
			hitCount++;
			if (hitCount >= 3)
			{
				hitCount = 0;
				projectile.localAI[1] = 1;
				Main.PlaySound(SoundID.Item14, projectile.position);
				//Projectile.NewProjectile(projectile.position, Vector2.Zero, mod.ProjectileType("GravityBouncerExplosion"), (int)(projectile.damage), projectile.knockBack, Main.player[projectile.owner].whoAmI);
				for (int i = -10; i < 10; i++)
				{
					//if (i != 0)
					{
						int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 162, 6 * i, ((10 - Math.Abs(i)) * 5), 100, default(Color), 3f * projectile.scale);
						Main.dust[dust].noGravity = true;
						dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + (i * 5)), projectile.width, projectile.height, 162, 6 * i, ((10 - Math.Abs(i)) * -5), 100, default(Color), 3f * projectile.scale);
						Main.dust[dust].noGravity = true;
					}
				}

				Vector2 oldSize = projectile.Size;
				projectile.position = projectile.Center;
				projectile.Size += new Vector2(256);
				projectile.Center = projectile.position;

				projectile.tileCollide = false;
				projectile.Damage();

				projectile.position = projectile.Center;
				projectile.Size = oldSize;
				projectile.Center = projectile.position;
				projectile.tileCollide = true;
				projectile.localAI[1] = 0;
			}
			if (!held)
				return;
			if (controlDelay <= 0)
			{
				controlDelay = 6;
			}
			if (projectile.velocity == Vector2.Zero)
			{
				projectile.velocity = new Vector2(0, -1);
			}
			projectile.velocity.Normalize();
			projectile.velocity *= -24 * Main.player[projectile.owner].GetModPlayer<ECPlayer>().tkVel;
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
