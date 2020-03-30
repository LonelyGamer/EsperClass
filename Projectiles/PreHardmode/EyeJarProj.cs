using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class EyeJarProj : ECProjectile
	{
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 16;
			projectile.height = 10;
			projectile.aiStyle = 36;
			projectile.penetrate = 3;
			Main.projFrames[projectile.type] = 2;
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
				if (projectile.frame > 1)
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
	}
}
