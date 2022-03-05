using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Projectiles.Hardmode.CrossMod
{
    public class AdeptSawblade : BaseSawbladeProj
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            maxVel = 16f;
        }

        public override void PostAI()
        {
            Dust dust;
            Vector2 position = projectile.position + projectile.velocity;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 89, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
        }
    }
}
