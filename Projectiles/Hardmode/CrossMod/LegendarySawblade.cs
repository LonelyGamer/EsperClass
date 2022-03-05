using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Projectiles.Hardmode.CrossMod
{
    public class LegendarySawblade : BaseSawbladeProj
    {
		int homingDelay;
        public override void SetDefaults()
        {
            base.SetDefaults();
			projectile.width = 32;
			projectile.height = 32;
            maxVel = 24f;
			projectile.localNPCHitCooldown = 10;
			projectile.usesLocalNPCImmunity = true;
        }

        public override void PostAI()
        {
            Dust dust;
            Vector2 position = projectile.position + projectile.velocity;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 87, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
			homingDelay++;
			if (homingDelay >= 20)
			{
				homingDelay -= 20;
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("LegendarySawbladeProj2"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
			}
        }
    }
}
