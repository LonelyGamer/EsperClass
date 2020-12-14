using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class SpikyBallLobberProj : ECProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(24);
			projectile.thrown = false;
			projectile.timeLeft = 180;
		}

		public override void AI()
		{
			ExtraAI();
			if (projectile.velocity.Y < -2)
				projectile.velocity.Y = -2;
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = false;
			return true;
		}
	}
}
