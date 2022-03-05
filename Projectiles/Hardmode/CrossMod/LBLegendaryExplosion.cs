using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Projectiles.Hardmode.CrossMod
{
	//This is copied over from LootBag's LegendaryExplosion
    public class LBLegendaryExplosion : LBEpicExplosion
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Legendary Explosion");
        }

        public override void AI()
        {
			ExtraAI();
            Dust dust;
            Vector2 position = projectile.position + projectile.velocity;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 87, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
            dust.scale = 2;
        }
    }
}
