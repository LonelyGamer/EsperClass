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
    public class ChlorophyteCanisterProj : BaseCanisterProj
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            projectile.penetrate = -1;
			projectile.localNPCHitCooldown = -1;
			projectile.usesLocalNPCImmunity = true;
			dustNum = 157;
        }
    }
}
