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
    public class HallowedCanisterProj : BaseCanisterProj
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            projectile.penetrate = -1;
			dustNum = 57;
        }
    }
}
