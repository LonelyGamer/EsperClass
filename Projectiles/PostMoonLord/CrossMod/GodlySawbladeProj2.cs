using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Projectiles.PostMoonLord.CrossMod
{
    public class GodlySawbladeProj2 : ECProjectile
    {
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

        public override void SetDefaults()
        {
			projectile.width = 22;
			projectile.height = 22;
            projectile.friendly = true;
            projectile.timeLeft = 600;
            projectile.tileCollide = true;
        }

		//Based on Loot Bags mod's GodlyStaffProj
		public override void AI()
		{
			ExtraAI();
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            Dust dust;
            Vector2 position = projectile.position + projectile.velocity;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 87, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;

			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 400f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && !Main.npc[k].immortal)
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target)
			{
				AdjustMagnitude(ref move);
				projectile.velocity = (10 * projectile.velocity + move) / 11f;
				AdjustMagnitude(ref projectile.velocity);
			}
			else
			{
				projectile.localAI[1] = 1;
				projectile.Kill();
			}
		}

		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 24f)
			{
				vector *= 24f / magnitude;
			}
		}

        public override bool PreKill(int timeLeft)
        {
			if (projectile.localAI[1] != 1)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("LBGodlyExplosion"), projectile.damage, 0, Main.myPlayer, 0f, 0f);
				Main.PlaySound(SoundID.Item14.WithVolume(0.5f), (int)projectile.Center.X, (int)projectile.Center.Y);
			}
            return true;
        }
    }
}
