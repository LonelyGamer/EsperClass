using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PostMoonLord.CrossMod
{
    public class LBGodlyExplosion : ECProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Godly Explosion");
        }

        public override void SetDefaults()
        {
            projectile.width = 100;
            projectile.height = 100;
            projectile.friendly = true;
            projectile.penetrate = 100;
            projectile.timeLeft = 300;
            projectile.tileCollide = false;
            projectile.alpha = 255;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 0;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 3;
        }

        public override void AI()
        {
            Dust dust;
            Vector2 position = projectile.position + projectile.velocity;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 90, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
            dust.scale = 2;
        }
    }
}
