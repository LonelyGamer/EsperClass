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
    public class TrueHallowedCanister : BaseCanister
    {
		int fireTimer = 0;

        public override void SetDefaults()
        {
            base.SetDefaults();
            projectile.width = 16;
            projectile.height = 30;
            projType = mod.ProjectileType("TrueHallowedCanisterProj");
            pourSpeed = 5f;
        }

		public override void PostAI()
		{
			if (!held)
			{
				return;
			}
			fireTimer++;
			if (fireTimer >= 30)
			{
				Vector2 targetPos = projectile.position;
				float targetDist = 400f;
				bool target = false;

				for (int k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					if (npc.CanBeChasedBy(this, false))
					{
						float distance = Vector2.Distance(npc.Center, projectile.Center);
						if ((distance < targetDist) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
						{
							targetPos = npc.Center;
							target = true;
						}
					}
				}
				if (target)
				{
					if (Main.myPlayer == projectile.owner)
					{
						Vector2 shootVel = targetPos - projectile.Center;
						if (shootVel == Vector2.Zero)
						{
							shootVel = new Vector2(0f, 1f);
						}
						shootVel.Normalize();
						shootVel *= 12f;
						Main.PlaySound(SoundID.Item43, (int)projectile.position.X, (int)projectile.position.Y);
						int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootVel.X, shootVel.Y, mod.ProjectileType("TrueHallowedCanisterProj2"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
						fireTimer = 0;
						if (rotate)
						{
							projectile.rotation = targetPos.ToRotation();
							if (projectile.rotation > 1.57079637f || projectile.rotation < -1.57079637f)
							{
								projectile.direction = -1;
							}
							else
							{
								projectile.direction = 1;
							}
						}
					}
				}
			}
			base.PostAI();
		}
    }
}
