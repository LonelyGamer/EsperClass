using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PostMoonLord
{
	public class EldritchEyeJarProj : BaseJarProj
	{
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 16;
			projectile.height = 10;
			projectile.aiStyle = 36;
			projectile.ignoreWater = true;
			projectile.timeLeft = 300;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			//projectile.extraUpdates = 3;
			Main.projFrames[projectile.type] = 2;
			chaseLiquid = true;
			chaseSpeed = 20f;
			chaseAcc = 1f;
			ignoreLoS = true;
		}

		public override void ExtraAI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 7)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame > 1)
				{
					projectile.frame = 0;
				}
			}
			/*if (hasTarget)
			{
				projectile.localAI[0]++;
				if (projectile.localAI[0] >= 10)
				{
					projectile.localAI[0] -= 10;
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("EldritchEyeJarProj2"), projectile.damage, projectile.knockBack, projectile.owner, 0f, projectile.whoAmI);
				}
			}*/
			/*Tile tile = Framing.GetTileSafetly((int)projectile.center.X / 16, (int)projectile.center.Y / 16);
			if (tile.Active())
			{
			}*/
			Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), 1f, 1f, 1f);
			int num445 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 204, 0f, 0f, 150, default(Color), 0.8f);
			Dust dust81 = Main.dust[num445];
			Main.dust[num445].fadeIn = 0.75f;
			dust81.velocity *= 0.1f;
			base.ExtraAI();
		}

		/*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCImmunity[target.whoAmI] = 10;
			target.immune[projectile.owner] = 0;
			projectile.Kill();
			base.OnHitNPC(target, damage, knockback, crit);
		}*/

		/*public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item14, projectile.position);
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 16;
			projectile.height = 10;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			for (int i = 0; i < 20; i++)
			{
				Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), 1f, 1f, 1f);
				int num445 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 204, 0f, 0f, 150, default(Color), 0.8f);
				Dust dust81 = Main.dust[num445];
				Main.dust[num445].fadeIn = 0.75f;
				dust81.velocity *= 0.1f;
			}
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 128;
			projectile.height = 128;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			for (int i = 0; i < 20; i++)
			{
				Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), 1f, 1f, 1f);
				int num445 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 204, 0f, 0f, 150, default(Color), 0.8f);
				Dust dust81 = Main.dust[num445];
				Main.dust[num445].fadeIn = 0.75f;
				dust81.velocity *= 0.1f;
			}
			if (projectile.owner == Main.myPlayer)
			{
				projectile.localAI[1] = -1f;
				projectile.maxPenetrate = 0;
				projectile.Damage();
			}
			base.Kill(timeLeft);
		}*/
	}
}
