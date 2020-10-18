﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
    public class TrueNightCanister : BaseCanister
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            projectile.width = 26;
            projectile.height = 42;
			releaseRate = 10;
            projType = mod.ProjectileType("TrueNightCanisterProj");
            pourSpeed = 8f;
        }
    }
}
