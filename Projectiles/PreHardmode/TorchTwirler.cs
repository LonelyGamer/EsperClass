using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class TorchTwirler : ECProjectile
	{
		protected int dir = 1;
		protected int twirlerDust;
		protected float dustR;
		protected float dustG;
		protected float dustB;
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 34;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.coldDamage = true;
			maxVel = 16f;
			whizze = false;
			rotate = false;
			twirlerDust = 6;
			dustR = 1f;
			dustG = 0.95f;
			dustB = 0.8f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			//projectile.position -= projectile.velocity;
			if ((double)projectile.velocity.X != (double)oldVelocity.X)
				projectile.velocity.X = -Math.Sign(projectile.velocity.X);
			if ((double)projectile.velocity.Y != (double)oldVelocity.Y)
				projectile.velocity.Y = -Math.Sign(projectile.velocity.Y);
			return false;
		}

		public override void PostAI()
		{
			if (projectile.velocity.X != 0)
				dir = Math.Sign(projectile.velocity.X);
			projectile.rotation -= dir * 6;
			if (!projectile.wet && !projectile.lavaWet)
			{
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, twirlerDust, 0f, 0f, 100, default(Color), 1f);
				Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), dustR, dustG, dustB);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(BuffID.OnFire, 180, false);
			}
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
