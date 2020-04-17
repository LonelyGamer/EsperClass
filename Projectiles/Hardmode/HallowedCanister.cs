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
    public class HallowedCanister : LiquidNitrogenCanister
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            projectile.width = 14;
            projectile.height = 22;
            projType = mod.ProjectileType("HallowedCanisterProj");
            pourSpeed = 5f;
        }
    }
}
