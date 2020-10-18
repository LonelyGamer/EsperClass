using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Projectiles.Hardmode.CrossMod
{
    public class EpicSawblade : BaseSawbladeProj
    {
		int explosionDelay;
        public override void SetStaticDefaults()
        {
            base.SetDefaults();
			projectile.width = 38;
			projectile.height = 38;
            maxVel = 24f;
        }

        public override void PostAI()
        {
            Dust dust;
            Vector2 position = projectile.position + projectile.velocity;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 27, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
			if (explosionDelay > 0)
				explosionDelay--;
        }

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (explosionDelay <= 0)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("LBEpicExplosion"), projectile.damage, 0, Main.myPlayer, 0f, 0f);
				Main.PlaySound(SoundID.Item14.WithVolume(0.5f), (int)projectile.Center.X, (int)projectile.Center.Y);
				explosionDelay = 15;
			}
			base.OnHitNPC(target, damage, knockback, crit);
		}
    }
}
