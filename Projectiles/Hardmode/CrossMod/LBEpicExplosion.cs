using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Projectiles.Hardmode.CrossMod
{
	//This is copied over from LootBag's EpicExplosion
    public class LBEpicExplosion : ECProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Epic Explosion");
        }

        public override void SetDefaults()
        {
            projectile.width = 100;
            projectile.height = 100;
            projectile.friendly = true;
            projectile.penetrate = 10;
            projectile.timeLeft = 5;
            projectile.tileCollide = false;
            projectile.alpha = 255;
			projectile.localNPCHitCooldown = -1;
			projectile.usesLocalNPCImmunity = true;
        }

        public override void AI()
        {
			ExtraAI();
            Dust dust;
            Vector2 position = projectile.position + projectile.velocity;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 27, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
            dust.scale = 2;
        }
    }
}
