using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class TKThornBall : BaseBoulderProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 30;
			projectile.height = 30;
			projectile.penetrate = 20;
			maxVel = 20f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			touched = true;
			if (held)
				return true;
			else
			{
				if ((projectile.velocity.X != oldVelocity.X && (oldVelocity.X < -3f || oldVelocity.X > 3f)) || (projectile.velocity.Y != oldVelocity.Y && (oldVelocity.Y < -3f || oldVelocity.Y > 3f)))
				{
					Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
					Main.PlaySound(0, (int)projectile.Center.X, (int)projectile.Center.Y, 1, 1f, 0f);
				}
				return false;
			}
		}
	}
}
