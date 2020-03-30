using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class HellbatJarProj : ECProjectile
	{
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 16;
			projectile.height = 10;
			projectile.aiStyle = 36;
			projectile.penetrate = 5;
			Main.projFrames[projectile.type] = 3;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.velocity.X != oldVelocity.X)
			{
				projectile.velocity.X = 0f - oldVelocity.X;
			}
			if (projectile.velocity.Y != oldVelocity.Y)
			{
				projectile.velocity.Y = 0f - oldVelocity.Y;
			}
			return projectile.penetrate <= 0;
		}

		public override void ExtraAI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 7)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame > 2)
				{
					projectile.frame = 0;
				}
			}
			base.ExtraAI();
		}

		public override void AI()
		{
			ExtraAI();
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(3) == 0)
				target.AddBuff(BuffID.OnFire, 180, false);
			base.OnHitNPC(target, damage, knockback, crit);
		}

		public override void PostAI()
		{
			if (Main.rand.Next(3) == 0)
			{
				Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), projectile.light, projectile.light *= 0.8f, projectile.light *= 0.6f);
				int num130 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.8f);
				Dust dust3 = Main.dust[num130];
				dust3.velocity += projectile.velocity * 0.2f;
				Main.dust[num130].noGravity = true;
			}
		}
	}
}
