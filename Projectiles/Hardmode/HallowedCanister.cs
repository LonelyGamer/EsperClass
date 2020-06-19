using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
    public class HallowedCanister : BaseCanister
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            projectile.width = 14;
            projectile.height = 22;
			releaseRate = 15;
            projType = mod.ProjectileType("HallowedCanisterProj");
            pourSpeed = 5f;
        }
    }
}
