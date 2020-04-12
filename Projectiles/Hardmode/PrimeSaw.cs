using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class PrimeSaw : ECProjectile
	{
		Vector2 targetPos = Vector2.Zero;

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 44;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			maxVel = 16f;
			whizze = false;
			rotate = false;
			Main.projFrames[projectile.type] = 4;
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

		public override void PostAI()
		{
			if (projectile.velocity != Vector2.Zero)
			{
				projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 1.57f;
				targetPos.X = Main.mouseX + Main.screenPosition.X + projectile.velocity.X;
				targetPos.Y = Main.mouseY + Main.screenPosition.Y + projectile.velocity.Y;
			}
		}

		public override void ExtraAI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 3)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame > 3)
				{
					projectile.frame = 0;
				}
			}
			base.ExtraAI();
		}
	}
}
