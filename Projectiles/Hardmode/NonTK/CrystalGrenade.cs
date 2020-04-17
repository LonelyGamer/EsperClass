using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Projectiles.Hardmode.NonTK
{
    public class CrystalGrenade : ModProjectile //Adapted from ExampleExplosive by Domlight, touched up by TheLoneGamer
    {
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.thrown = true;
			projectile.timeLeft = 180;
			//projectile.localNPCHitCooldown = 10;
			//projectile.usesLocalNPCImmunity = true;
			/*drawOffsetX = 5;
			drawOriginOffsetY = 5;*/
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.ai[1] != 0)
			{
				return true;
			}
			projectile.soundDelay = 10;
			return false;
		}

		public override void AI()
		{
			/*ai[0] = 10f;
			if (base.velocity.Y == 0f && base.velocity.X != 0f)
			{
				base.velocity.X = base.velocity.X * 0.97f;
				if (type == 29 || type == 470 || type == 637)
				{
					base.velocity.X = base.velocity.X * 0.99f;
				}
				if ((double)base.velocity.X > -0.01 && (double)base.velocity.X < 0.01)
				{
					base.velocity.X = 0f;
					netUpdate = true;
				}
			}*/
			// Smoke and fuse dust spawn.
			if (Main.rand.NextBool())
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
				Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].position = projectile.Center + new Vector2(0f, (float)(-(float)projectile.height / 2)).RotatedBy((double)projectile.rotation, default(Vector2)) * 1.1f;
				dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].position = projectile.Center + new Vector2(0f, (float)(-(float)projectile.height / 2 - 6)).RotatedBy((double)projectile.rotation, default(Vector2)) * 1.1f;
			}
			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 5f)
			{
				projectile.ai[0] = 10f;
				if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
				{
					projectile.velocity.X = projectile.velocity.X * 0.97f;
					if ((double)projectile.velocity.X > -0.01 && (double)projectile.velocity.X < 0.01)
					{
						projectile.velocity.X = 0f;
						projectile.netUpdate = true;
					}
				}
				projectile.velocity.Y = projectile.velocity.Y + 0.2f;
			}
			projectile.rotation += projectile.velocity.X * 0.1f;
			return;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item27, projectile.position);
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 128;
			projectile.height = 128;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			for (int i = 0; i < 20; i++)
			{
				int num695 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 68);
				Main.dust[num695].noGravity = true;
				Dust dust24 = Main.dust[num695];
				dust24.velocity *= 1.5f;
				Main.dust[num695].scale *= 0.9f;
			}
			if (Main.myPlayer == projectile.owner)
			{
				for (int j = 0; j < 12; j++)
				{
					float num697 = (0f - projectile.velocity.X) * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
					float num696 = (0f - projectile.velocity.Y) * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
					int crystalShards = Projectile.NewProjectile(projectile.position.X + Main.rand.Next(projectile.width), projectile.position.Y + Main.rand.Next(projectile.height), num697, num696, ProjectileID.CrystalShard, projectile.damage, 0f, Main.myPlayer);
					Main.projectile[crystalShards].ranged = false;
					Main.projectile[crystalShards].thrown = true;
				}
			}
			base.Kill(timeLeft);
		}
	}
}
