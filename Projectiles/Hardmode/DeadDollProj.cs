using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
    public class DeadDollProj : ECProjectile
    {
        public override void SetDefaults()
        {
			projectile.friendly = true;
			projectile.width = 2;
			projectile.height = 12;
			projectile.timeLeft = 300;
			projectile.penetrate = -1;
			projectile.localNPCHitCooldown = -1;
			projectile.usesLocalNPCImmunity = true;
        }

		public override void AI()
		{
			ExtraAI();
		}
    }
}
