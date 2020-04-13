using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Projectiles.Hardmode
{
    public class GreenTKRocket : RedTKRocket
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            maxVel = 12f;
            rotate = false;
            whizze = false;
            canReturn = false;
        }
    }
}
