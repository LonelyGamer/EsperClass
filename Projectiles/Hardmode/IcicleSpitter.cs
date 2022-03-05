using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class IcicleSpitter : ECProjectile
	{
		int fireDelay = 0;
		int secondaryFire = 0;
		Vector2 targetPos = Vector2.Zero;

		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.DontAttachHideToAlpha[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.hide = true;
			projectile.noEnchantments = true;
			maxVel = 16f;
			whizze = false;
			rotate = false;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}

		public override void PostAI()
		{
			if (projectile.velocity != Vector2.Zero)
			{
				projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 0.785f;
				targetPos.X = Main.mouseX + Main.screenPosition.X + projectile.velocity.X;
				targetPos.Y = Main.mouseY + Main.screenPosition.Y + projectile.velocity.Y;
			}
			if (!held)
			{
				return;
			}
			fireDelay++;
			secondaryFire++;
			if (fireDelay >= 6)
			{
				fireDelay -= 6;
				if (projectile.owner == Main.myPlayer)
				{
					Vector2 shootVel = targetPos - projectile.Center;
					if (shootVel == Vector2.Zero)
					{
						shootVel = new Vector2(0f, 1f);
					}
					shootVel.Normalize();
					if (secondaryFire >= 60)
					{
						shootVel *= 24;
						secondaryFire -= 60;
						Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
						Main.PlaySound(SoundID.Item8, projectile.position);
						Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootVel.X, shootVel.Y, mod.ProjectileType("IcicleSpitterProj2"), projectile.damage * 2, projectile.knockBack * 2, Main.myPlayer, 0f, 0f);
					}
					else
					{
						shootVel *= 16;
						Vector2 perturbedSpeed = new Vector2(shootVel.X, shootVel.Y).RotatedByRandom(MathHelper.ToRadians(15));
						shootVel.X = perturbedSpeed.X;
						shootVel.Y = perturbedSpeed.Y;
						Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
						int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootVel.X, shootVel.Y, mod.ProjectileType("IcicleSpitterProj1"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
						Main.projectile[proj].frame = Main.rand.Next(5);
					}
				}
			}
		}

		public override bool? CanCutTiles()
		{
			return false;
		}

		public override bool? CanHitNPC(NPC npc)
		{
			return false;
		}

		public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
		{
			drawCacheProjsBehindNPCs.Add(index);
		}
	}
}
