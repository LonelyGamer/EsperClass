using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class CactusBall : ECProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			maxVel = 16f;
			whizze = false;
			rotate = false;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (!held)
				return;
			if (controlDelay <= 0)
			{
				controlDelay = 10;
			}
			if (projectile.velocity == Vector2.Zero)
			{
				projectile.velocity = new Vector2(0, -1);
			}
			projectile.velocity.Normalize();
			projectile.velocity *= -16;
			/*if (target.position.X < projectile.position.X + projectile.width * 0.5f)
				projectile.velocity.X = 16;
			else
				projectile.velocity.X = -16;*/
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
