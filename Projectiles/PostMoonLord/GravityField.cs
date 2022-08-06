using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PostMoonLord
{
	public class GravityField : ECProjectile
	{
		int auraRadius = 32;
		public override void SetDefaults()
		{
			projectile.width = 64;
			projectile.height = 64;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 1200;
			projectile.penetrate = -1;
			//projectile.alpha = 128;
			projectile.localNPCHitCooldown = 6;
			projectile.usesLocalNPCImmunity = true;
			projectile.noEnchantments = true;
			projectile.hide = true;
		}

		public override void AI()
		{
			ExtraAI();
			Lighting.AddLight((int)(projectile.Center.X), (int)(projectile.Center.Y), 1f, 0f, 0.7f);
			//float distance = Vector2.Distance(projectile.Center, Main.myPlayer.Center);
			if (Vector2.Distance(projectile.Center, Main.player[projectile.owner].Center) <= auraRadius)
			{
				Main.player[projectile.owner].wingTime++;
			}
			for (int i = 0; i < (int)(auraRadius / 2); i++)
			{
				Vector2 dustPos = projectile.Center + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / (auraRadius / 2) * i)) * ((auraRadius + auraRadius) / 2);
				int dustIndex = Dust.NewDust(dustPos, 1, 1, 162);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity = Vector2.Zero;
			}
			if (auraRadius < 256)
			{
				auraRadius += 2;
				projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
				projectile.width = auraRadius * 2;
				projectile.height = auraRadius * 2;
				projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
				if (auraRadius == 256)
				{
					Main.PlaySound(SoundLoader.customSoundType, (int)projectile.Center.X, (int)projectile.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/GravityFieldReady"));
					for (int i = 0; i < 50; i++)
					{
						int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[dust].velocity.X = (12 + Main.rand.Next(-4, 4));
						if (Main.rand.Next(2) == 0)
							Main.dust[dust].velocity.X *= -1;
						Main.dust[dust].velocity.Y = 0;
					}
				}
			}
			//else
			//	projectile.rotation += 0.1046f * projectile.direction;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.Center.X < projectile.Center.X)
				hitDirection = 1;
			else
				hitDirection = -1;

			if (target.knockBackResist > 0f)
			{
				if (target.Center.X < projectile.Center.X)
					target.velocity.X = 8 * target.knockBackResist;
				else
					target.velocity.X = -8 * target.knockBackResist;
				if (target.Center.Y < projectile.Center.Y)
					target.velocity.Y = 8 * target.knockBackResist;
				else
					target.velocity.Y = -8 * target.knockBackResist;
			}
			base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
		}
	}
}
