using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class PearlCactusBall : ECProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 26;
			projectile.height = 26;
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
			projectile.position -= projectile.velocity;
			if ((double)projectile.velocity.X != (double)oldVelocity.X)
				projectile.velocity.X = -oldVelocity.X;
			if ((double)projectile.velocity.Y != (double)oldVelocity.Y)
				projectile.velocity.Y = -oldVelocity.Y;
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
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
