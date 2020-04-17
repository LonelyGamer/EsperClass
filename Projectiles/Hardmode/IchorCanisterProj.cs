using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
    public class IchorCanisterProj : BaseCanisterProj
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            dustColor = new Color(254, 202, 80, 1);
			projectile.penetrate = 10;
			dustNum = 170;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 300, false);
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}
