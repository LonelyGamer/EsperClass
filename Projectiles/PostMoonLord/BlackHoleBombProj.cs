using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PostMoonLord
{
	public class BlackHoleBombProj : ECProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 512;
			projectile.height = 512;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}

		public override void AI()
		{
			ExtraAI();
			projectile.timeLeft++;
			if (Main.projectile[(int)projectile.ai[0]].active && Main.player[projectile.owner].channel)
			{
				projectile.rotation += 0.1046f * projectile.direction;
				projectile.position = Main.projectile[(int)projectile.ai[0]].Center - projectile.Size / 2f;
			}
			else
			{
				projectile.Kill();
				return;
			}

			//Item Pickup
			for (int i = 0; i < Main.item.Length - 1; i++)
			{
				if (Main.item[i].active)
				{
					Vector2 dist = projectile.position;
					Vector2 vector2;
					vector2.X = (float)(Main.item[i].position.X);
					vector2.Y = (float)(Main.item[i].position.Y);
					if (Vector2.Distance(vector2, dist) <= 512f)
					{
						float Speed = Vector2.Distance(vector2, dist) / 32f;
						float rotation = (float)Math.Atan2(Main.item[i].position.Y - (projectile.position.Y + (projectile.height * 0.5f)), Main.item[i].position.X - (projectile.position.X + (projectile.width * 0.5f)));
						Main.item[i].velocity.X = (float)((Math.Cos(rotation) * Speed) * -1);
						Main.item[i].velocity.Y = (float)((Math.Sin(rotation) * Speed) * -1);
						Main.item[i].beingGrabbed = true;
					}
				}
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 6;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.position.X + target.width * 0.5f < projectile.position.X + projectile.width * 0.5f)
				hitDirection = 1;
			else
				hitDirection = -1;

			if (target.knockBackResist > 0f)
			{
				if (target.position.Y + target.height * 0.5f < projectile.position.Y + projectile.height * 0.5f)
				{
					target.velocity.Y = knockback * target.knockBackResist;
				}
				else
				{
					target.velocity.Y = -knockback * target.knockBackResist;
				}
			}
			base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
		}
	}
}
