using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
    public class LiquidNitrogenCanisterProj : BaseCanisterProj
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            dustColor = new Color(0, 80, 255, 100);
			projectile.penetrate = 5;
			dustNum = 135;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(mod.BuffType("NPCChill"), 30, false);
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}
