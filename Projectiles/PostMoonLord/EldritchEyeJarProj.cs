using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PostMoonLord
{
	public class EldritchEyeJarProj : BaseJarProj
	{
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 16;
			projectile.height = 10;
			projectile.aiStyle = 36;
			projectile.penetrate = -1;
			projectile.ignoreWater = true;
			projectile.timeLeft = 300;
			//projectile.extraUpdates = 3;
			Main.projFrames[projectile.type] = 2;
			chaseLiquid = true;
			chaseSpeed = 20f;
			chaseAcc = 1f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.velocity.X != oldVelocity.X)
				projectile.velocity.X = 0f - oldVelocity.X;
			if (projectile.velocity.Y != oldVelocity.Y)
				projectile.velocity.Y = 0f - oldVelocity.Y;
			return false;
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
			/*Tile tile = Framing.GetTileSafetly((int)projectile.center.X / 16, (int)projectile.center.Y / 16);
			if (tile.Active())
			{
			}*/
			Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), 1f, 1f, 1f);
			int num445 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 204, 0f, 0f, 150, default(Color), 0.8f);
			Dust dust81 = Main.dust[num445];
			Main.dust[num445].fadeIn = 0.75f;
			dust81.velocity *= 0.1f;
			base.ExtraAI();
		}
	}
}
