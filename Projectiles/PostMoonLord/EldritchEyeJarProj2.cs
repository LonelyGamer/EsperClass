using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EsperClass.Projectiles.PostMoonLord
{
    public class EldritchEyeJarProj2 : ECProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 26;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.localNPCHitCooldown = -1;
			projectile.usesLocalNPCImmunity = true;
			Main.projFrames[projectile.type] = 4;
			projectile.timeLeft = 180;
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

		public override void AI()
		{
			ExtraAI();
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
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);// + 1.57f;
		}
	}
}
