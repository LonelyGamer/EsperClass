using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class TKMeteor : ECProjectile
	{
		//bool doOnce = false;
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = 1;
			maxVel = 8f;
			whizze = false;
			canReturn = false;
			//Main.projFrames[projectile.type] = 3;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 5;
			base.OnHitNPC(target, damage, knockback, crit);
		}

		public override void ExtraAI()
		{
			/*if (!doOnce)
			{
				projectile.frame = Main.rand.Next(3);
				doOnce = true;
			}*/
			if (!held)
			{
				projectile.velocity.Y += 0.2f;
			}
			base.ExtraAI();
		}

		public override void Kill(int timeLeft)
		{
			if (held)
				Main.player[projectile.owner].channel = false;
		  Main.PlaySound(SoundID.Item89, projectile.position);
		  projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
		  projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
		  projectile.width = (int)(192f * projectile.scale);
		  projectile.height = (int)(192f * projectile.scale);
		  projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
		  projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
		  int num3;
		  for (int num337 = 0; num337 < 8; num337 = num3 + 1)
		  {
		    Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
		    num3 = num337;
		  }
		  for (int num338 = 0; num338 < 32; num338 = num3 + 1)
		  {
		    int num339 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2.5f);
		    Main.dust[num339].noGravity = true;
		    Dust dust = Main.dust[num339];
		    dust.velocity *= 3f;
		    num339 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
		    dust = Main.dust[num339];
		    dust.velocity *= 2f;
		    Main.dust[num339].noGravity = true;
		    num3 = num338;
		  }
		  for (int num340 = 0; num340 < 2; num340 = num3 + 1)
		  {
		    int num341 = Gore.NewGore(projectile.position + new Vector2((float)(projectile.width * Main.rand.Next(100)) / 100f, (float)(projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, default(Vector2), Main.rand.Next(61, 64), 1f);
		    Gore gore = Main.gore[num341];
		    gore.velocity *= 0.3f;
		    Gore gore43 = Main.gore[num341];
		    gore43.velocity.X = gore43.velocity.X + (float)Main.rand.Next(-10, 11) * 0.05f;
		    Gore gore44 = Main.gore[num341];
		    gore44.velocity.Y = gore44.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.05f;
		    num3 = num340;
		  }
		  if (projectile.owner == Main.myPlayer)
		  {
		    projectile.localAI[1] = -1f;
		    projectile.maxPenetrate = 0;
		    projectile.Damage();
		  }
		  for (int num342 = 0; num342 < 5; num342 = num3 + 1)
		  {
		    int num343 = Utils.SelectRandom<int>(Main.rand, new int[]
		    {
		      6,
		      259,
		      158
		    });
		    int num344 = Dust.NewDust(projectile.position, projectile.width, projectile.height, num343, 2.5f * (float)projectile.direction, -2.5f, 0, default(Color), 1f);
		    Main.dust[num344].alpha = 200;
		    Dust dust = Main.dust[num344];
		    dust.velocity *= 2.4f;
		    dust = Main.dust[num344];
		    dust.scale += Main.rand.NextFloat();
		    num3 = num342;
		  }
			base.Kill(timeLeft);
		}
	}
}
