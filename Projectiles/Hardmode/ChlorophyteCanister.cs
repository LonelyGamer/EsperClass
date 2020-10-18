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
    public class ChlorophyteCanister : BaseCanister
    {
		int fireTimer = 0;

        public override void SetDefaults()
        {
            base.SetDefaults();
            projectile.width = 30;
            projectile.height = 34;
            projType = mod.ProjectileType("ChlorophyteCanisterProj");
            pourSpeed = 5f;
        }

		public override void PostAI()
		{
			if (!held)
			{
				return;
			}
			fireTimer++;
			if (fireTimer >= 60)
			{
				fireTimer = 0;
				Main.PlaySound(SoundID.Item8, projectile.position);
				if (projectile.owner == Main.myPlayer)
				{
					int chlorophyteOrb = Projectile.NewProjectile(projectile.Center.X + projectile.velocity.X, projectile.Center.Y + projectile.velocity.Y, 0, 12, ProjectileID.ChlorophyteOrb, (int)(projectile.damage), projectile.knockBack, Main.player[projectile.owner].whoAmI);
					Main.projectile[chlorophyteOrb].melee = false;
				}
			}
			base.PostAI();
		}
    }
}
