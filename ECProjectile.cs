using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace EsperClass
{
	public abstract class ECProjectile : ModProjectile
	{
		protected float maxVel = 16f;
		protected float rateScale = 0f;
		protected float returnVel = 25f;
		protected bool whizze = false;
		protected bool rotate = false;
		protected bool held = true;
		protected bool canReturn = true;
		protected int controlDelay = 0;
		bool created = false;

		//Adapted from The Example Mod's Magic Missile code. Much neater and cleaner than the vanilla aiStyle 9 code
		/*public override void AI()
		{
			ExtraAI();
			if (rateScale == 0)
				rateScale = projectile.velocity.Length();
			float extraSpeed = Main.player[projectile.owner].GetModPlayer<ECPlayer>().tkVel;

			// In Multi Player (MP) This code only runs on the client of the projectile's owner, this is because it relies on mouse position, which isn't the same across all clients.
			if (Main.myPlayer == projectile.owner && projectile.ai[0] == 0f)
			{
				if (controlDelay > 0)
				{
					controlDelay--;
				}
				Player player = Main.player[projectile.owner];
				// If the player channels the weapon, do something. This check only works if item.channel is true for the weapon.
				if (player.channel)
				{
					held = true;
					Vector2 vectorToCursor = Main.MouseWorld - projectile.Center;
					float distanceToCursor = vectorToCursor.Length();

					if (whizze && distanceToCursor < 100f && controlDelay <= 0)
					{
						if (projectile.velocity.Length() < rateScale)
						{
							projectile.velocity *= 1.1f;
							if (projectile.velocity.Length() > rateScale)
							{
								projectile.velocity.Normalize();
								projectile.velocity *= rateScale * extraSpeed;
							}
						}
						if (projectile.ai[0] == 0f)
						{
							projectile.ai[0] = -10f;
						}
					}

					// Here we can see that the speed of the projectile depends on the distance to the cursor.
					if (distanceToCursor > maxVel * extraSpeed)
					{
						distanceToCursor = (maxVel * extraSpeed) / distanceToCursor;
						vectorToCursor *= distanceToCursor;
					}

					int velocityXBy1000 = (int)(vectorToCursor.X * 1000f);
					int oldVelocityXBy1000 = (int)(projectile.velocity.X * 1000f);
					int velocityYBy1000 = (int)(vectorToCursor.Y * 1000f);
					int oldVelocityYBy1000 = (int)(projectile.velocity.Y * 1000f);

					// This code checks if the precious velocity of the projectile is different enough from its new velocity, and if it is, syncs it with the server and the other clients in MP.
					// We previously multiplied the speed by 1000, then casted it to int, this is to reduce its precision and prevent the speed from being synced too much.
					if (velocityXBy1000 != oldVelocityXBy1000 || velocityYBy1000 != oldVelocityYBy1000)
					{
						projectile.netUpdate = true;
					}

					if (controlDelay <= 0)
					{
						projectile.velocity = vectorToCursor;
					}
				}
				// If the player stops channeling, do something else.
				else if (projectile.ai[0] <= 0f)
				{
					held = false;
					projectile.netUpdate = true;
					if (canReturn)
					{
						projectile.timeLeft = 120;
					}
					projectile.ai[0] = 1f;
				}
				if (canReturn)
				{
					projectile.localAI[0] += 1f;
					if (projectile.ai[0] > 0f && projectile.localAI[0] > 15f)
					{
						projectile.tileCollide = false;
						Vector2 vector12 = Main.player[projectile.owner].Center - projectile.Center;
						if (vector12.Length() < 20f)
						{
							projectile.Kill();
						}
						vector12.Normalize();
						vector12 *= returnVel * extraSpeed;
						projectile.velocity = (projectile.velocity * 5f + vector12) / 6f;
					}
					if (rotate)
					{
						if (projectile.ai[0] < 0f || (projectile.velocity.X == 0f && projectile.velocity.Y == 0f))
						{
							projectile.rotation += 0.3f;
						}
						else if (projectile.ai[0] > 0f)
						{
							projectile.rotation += 0.3f * (float)projectile.direction;
						}
						else
						{
							projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
						}
					}
					else if (rotate && (projectile.velocity.X != 0f || projectile.velocity.Y != 0f))
					{
						projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 2.355f;
					}
					if (projectile.velocity.Y > maxVel * extraSpeed)
					{
						projectile.velocity.Y = maxVel * extraSpeed;
						return;
					}
				}
			}
			
			// Set the rotation so the projectile points towards where it's going.
			if (rotate && projectile.velocity != Vector2.Zero)
			{
				projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver4;
			}
		}*/

		//Adopted from AiStyle 9
		public override void AI()
		{
			if (!created)
			{
				Main.player[projectile.owner].GetModPlayer<ECPlayer>().tkInUse = Main.player[projectile.owner].HeldItem.type;
				created = true;
			}
			ExtraAI();
			if (rateScale == 0)
				rateScale = projectile.velocity.Length();
			float extraSpeed = Main.player[projectile.owner].GetModPlayer<ECPlayer>().tkVel;
			if (Main.myPlayer == projectile.owner && projectile.ai[0] <= 0f)
			{
				if (controlDelay > 0)
				{
					controlDelay--;
				}
				if (Main.player[projectile.owner].channel && Main.player[projectile.owner].HeldItem.type == Main.player[projectile.owner].GetModPlayer<ECPlayer>().tkInUse)
				{
					held = true;
					projectile.timeLeft++;
					Vector2 vector10 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
					float num115 = (float)Main.mouseX + Main.screenPosition.X - vector10.X;
					float num116 = (float)Main.mouseY + Main.screenPosition.Y - vector10.Y;
					if (Main.player[projectile.owner].gravDir == -1f)
					{
						num116 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector10.Y;
					}
					float num117 = (float)Math.Sqrt((double)(num115 * num115 + num116 * num116));
					num117 = (float)Math.Sqrt((double)(num115 * num115 + num116 * num116));
					if (projectile.ai[0] < 0f)
					{
						projectile.ai[0] += 1f;
					}
					if (whizze && num117 < 100f && controlDelay <= 0)
					{
						if (projectile.velocity.Length() < rateScale)
						{
							projectile.velocity *= 1.1f;
							if (projectile.velocity.Length() > rateScale)
							{
								projectile.velocity.Normalize();
								projectile.velocity *= rateScale * extraSpeed;
							}
						}
						if (projectile.ai[0] == 0f)
						{
							projectile.ai[0] = -10f;
						}
					}
					else if (num117 > rateScale)
					{
						num117 = rateScale / num117;
						num115 *= num117 * extraSpeed;
						num116 *= num117 * extraSpeed;
						int num118 = (int)(num115 * 1000f);
						int num119 = (int)(projectile.velocity.X * 1000f);
						int num120 = (int)(num116 * 1000f);
						int num121 = (int)(projectile.velocity.Y * 1000f);
						if (num118 != num119 || num120 != num121)
						{
							projectile.netUpdate = true;
						}
						if (whizze && controlDelay <= 0)
						{
							Vector2 value5 = new Vector2(num115, num116);
							projectile.velocity = (projectile.velocity * 4f + value5) / 5f;
						}
						else if (controlDelay <= 0)
						{
							projectile.velocity.X = num115;
							projectile.velocity.Y = num116;
						}
					}
					else
					{
						int num122 = (int)(num115 * 1000f);
						int num123 = (int)(projectile.velocity.X * 1000f);
						int num124 = (int)(num116 * 1000f);
						int num125 = (int)(projectile.velocity.Y * 1000f);
						if (num122 != num123 || num124 != num125)
						{
							projectile.netUpdate = true;
						}
						if (controlDelay <= 0)
						{
							projectile.velocity.X = num115;
							projectile.velocity.Y = num116;
						}
					}
				}
				else if (projectile.ai[0] <= 0f)
				{
					held = false;
					projectile.netUpdate = true;
					if (canReturn)
					{
						projectile.timeLeft = 120;
					}
					projectile.ai[0] = 1f;
				}
			}
			if (canReturn)
			{
				projectile.localAI[0] += 1f;
				if (projectile.ai[0] > 0f && projectile.localAI[0] > 15f)
				{
					projectile.tileCollide = false;
					Vector2 vector12 = Main.player[projectile.owner].Center - projectile.Center;
					if (vector12.Length() < 20f)
					{
						projectile.Kill();
					}
					vector12.Normalize();
					vector12 *= returnVel * extraSpeed;
					projectile.velocity = (projectile.velocity * 5f + vector12) / 6f; //* extraSpeed;
				}
				if (rotate)
				{
					if (projectile.ai[0] < 0f || (projectile.velocity.X == 0f && projectile.velocity.Y == 0f))
					{
						projectile.rotation += 0.3f;
					}
					else if (projectile.ai[0] > 0f)
					{
						projectile.rotation += 0.3f * (float)projectile.direction;
					}
					else
					{
						projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
					}
				}
				else if (rotate && (projectile.velocity.X != 0f || projectile.velocity.Y != 0f))
				{
					projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 2.355f;
				}
				if (projectile.velocity.Y > maxVel * extraSpeed)
				{
					projectile.velocity.Y = maxVel * extraSpeed;
					return;
				}
			}
			else if (Main.player[projectile.owner].GetModPlayer<ECPlayer>().tkInUse > 0 && Main.player[projectile.owner].GetModPlayer<ECPlayer>().tkInUse != Main.player[projectile.owner].HeldItem.type)
			{
				Main.player[projectile.owner].GetModPlayer<ECPlayer>().tkInUse = Main.player[projectile.owner].HeldItem.type;
				Main.player[projectile.owner].channel = false;
			}
		}

		public virtual void ExtraAI()
		{
			ECPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<ECPlayer>();
			if (modPlayer.cambrianSetBonus)
				projectile.ignoreWater = true;
			if (!projectile.noEnchantments)
			{
				if (modPlayer.fireVial && Main.rand.Next(2) == 0)
				{
					int num5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 2.5f);
					Main.dust[num5].noGravity = true;
					Main.dust[num5].velocity *= 0.7f;
					Dust dust3 = Main.dust[num5];
					dust3.velocity.Y = dust3.velocity.Y - 0.5f;
				}
				if (modPlayer.frostburnVial && Main.rand.Next(2 * (1 + projectile.extraUpdates)) == 0)
				{
					int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
					Main.dust[num].noGravity = true;
					Main.dust[num].velocity *= 0.7f;
					Dust dust = Main.dust[num];
					dust.velocity.Y = dust.velocity.Y - 0.5f;
				}
				if (modPlayer.poisonVial && Main.rand.Next(4) == 0)
				{
					int num13 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 46, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num13].noGravity = true;
					Main.dust[num13].fadeIn = 1.5f;
					Main.dust[num13].velocity *= 0.25f;
				}
				if (modPlayer.cursedFlamesVial && Main.rand.Next(2) == 0)
				{
					int num4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 75, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 2.5f);
					Main.dust[num4].noGravity = true;
					Main.dust[num4].velocity *= 0.7f;
					Dust dust2 = Main.dust[num4];
					dust2.velocity.Y = dust2.velocity.Y - 0.5f;
				}
				if (modPlayer.ichorVial && Main.rand.Next(2) == 0)
				{
					int num7 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 169, 0f, 0f, 100, default(Color), 1f);
					Dust dust6 = Main.dust[num7];
					dust6.velocity.X = dust6.velocity.X + (float)projectile.direction;
					Dust dust7 = Main.dust[num7];
					dust7.velocity.Y = dust7.velocity.Y + 0.2f;
					Main.dust[num7].noGravity = true;
				}
				if (modPlayer.midasVial && Main.rand.Next(2) == 0)
				{
					int num6 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 1.1f);
					Main.dust[num6].noGravity = true;
					Dust dust4 = Main.dust[num6];
					dust4.velocity.X = dust4.velocity.X / 2f;
					Dust dust5 = Main.dust[num6];
					dust5.velocity.Y = dust5.velocity.Y / 2f;
				}
				if (modPlayer.shadowflameVial && Main.rand.Next(2) == 0)
				{
					int num15 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 27, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.2f);
					Main.dust[num15].position = (Main.dust[num15].position + projectile.Center) / 2f;
					Main.dust[num15].noGravity = true;
					Dust dust3 = Main.dust[num15];
					dust3.velocity *= 0.3f;
					dust3 = Main.dust[num15];
					dust3.velocity -= projectile.velocity * 0.1f;
				}
				if (modPlayer.venomVial && Main.rand.Next(3) == 0)
				{
					int num2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 171, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].fadeIn = 1.5f;
					Main.dust[num2].velocity *= 0.25f;
				}
			}
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			float critChance = Main.player[projectile.owner].GetModPlayer<ECPlayer>().tkCrit;
			crit = Main.rand.Next(1, 101) <= critChance;
		}

		/*public override void Kill(int timeLeft)
		{
			if (held)
				Main.player[projectile.owner].channel = false;
		}*/

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (held && !canReturn)
			{
				Main.player[projectile.owner].channel = false;
				held = false;
			}
			ECPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<ECPlayer>();
			if (!projectile.noEnchantments)
			{
				if (Main.rand.Next(4) == 0 && modPlayer.fireVial)
				{
					target.AddBuff(BuffID.OnFire, 180, false);
				}
				if (Main.rand.Next(4) == 0 && modPlayer.frostburnVial)
				{
					target.AddBuff(BuffID.Frostburn, 180, false);
				}
				if (Main.rand.Next(4) == 0 && modPlayer.poisonVial)
				{
					target.AddBuff(BuffID.Poisoned, 180, false);
				}
				if (Main.rand.Next(4) == 0 && modPlayer.midasVial)
				{
					target.AddBuff(BuffID.Midas, 600, false);
				}
				if (Main.rand.Next(4) == 0 && modPlayer.cursedFlamesVial)
				{
					target.AddBuff(BuffID.CursedInferno, 180, false);
				}
				if (Main.rand.Next(4) == 0 && modPlayer.ichorVial)
				{
					target.AddBuff(BuffID.Ichor, 300, false);
				}
				if (Main.rand.Next(4) == 0 && modPlayer.shadowflameVial) //Umbrakinesis
				{
					target.AddBuff(BuffID.ShadowFlame, 180, false);
				}
				if (Main.rand.Next(4) == 0 && modPlayer.venomVial)
				{
					target.AddBuff(BuffID.Venom, 180, false);
				}
			}
		}
	}

	public class ECProjectile2 : GlobalProjectile
	{
		public override void SetDefaults(Projectile projectile)
		{
			if (DetectPositives(projectile))
			{
				projectile.melee = false;
				projectile.ranged = false;
				projectile.magic = false;
				projectile.minion = false;
				projectile.thrown = false;
				projectile.sentry = false;
			}
		}

		public override void AI(Projectile projectile)
		{
			if (DetectPositives(projectile))
			{
				if (!projectile.noEnchantments)
				{
					ECPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<ECPlayer>();
					if (modPlayer.fireVial && Main.rand.Next(2) == 0)
					{
						int num5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 2.5f);
						Main.dust[num5].noGravity = true;
						Main.dust[num5].velocity *= 0.7f;
						Dust dust3 = Main.dust[num5];
						dust3.velocity.Y = dust3.velocity.Y - 0.5f;
					}
					if (modPlayer.frostburnVial && Main.rand.Next(2 * (1 + projectile.extraUpdates)) == 0)
					{
						int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num].noGravity = true;
						Main.dust[num].velocity *= 0.7f;
						Dust dust = Main.dust[num];
						dust.velocity.Y = dust.velocity.Y - 0.5f;
					}
					if (modPlayer.poisonVial && Main.rand.Next(4) == 0)
					{
						int num13 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 46, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num13].noGravity = true;
						Main.dust[num13].fadeIn = 1.5f;
						Main.dust[num13].velocity *= 0.25f;
					}
					if (modPlayer.cursedFlamesVial && Main.rand.Next(2) == 0)
					{
						int num4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 75, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 2.5f);
						Main.dust[num4].noGravity = true;
						Main.dust[num4].velocity *= 0.7f;
						Dust dust2 = Main.dust[num4];
						dust2.velocity.Y = dust2.velocity.Y - 0.5f;
					}
					if (modPlayer.ichorVial && Main.rand.Next(2) == 0)
					{
						int num7 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 169, 0f, 0f, 100, default(Color), 1f);
						Dust dust6 = Main.dust[num7];
						dust6.velocity.X = dust6.velocity.X + (float)projectile.direction;
						Dust dust7 = Main.dust[num7];
						dust7.velocity.Y = dust7.velocity.Y + 0.2f;
						Main.dust[num7].noGravity = true;
					}
					if (modPlayer.midasVial && Main.rand.Next(2) == 0)
					{
						int num6 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, default(Color), 1.1f);
						Main.dust[num6].noGravity = true;
						Dust dust4 = Main.dust[num6];
						dust4.velocity.X = dust4.velocity.X / 2f;
						Dust dust5 = Main.dust[num6];
						dust5.velocity.Y = dust5.velocity.Y / 2f;
					}
					if (modPlayer.shadowflameVial && Main.rand.Next(2) == 0)
					{
						int num15 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 27, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num15].position = (Main.dust[num15].position + projectile.Center) / 2f;
						Main.dust[num15].noGravity = true;
						Dust dust3 = Main.dust[num15];
						dust3.velocity *= 0.3f;
						dust3 = Main.dust[num15];
						dust3.velocity -= projectile.velocity * 0.1f;
					}
					if (modPlayer.venomVial && Main.rand.Next(3) == 0)
					{
						int num2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 171, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num2].noGravity = true;
						Main.dust[num2].fadeIn = 1.5f;
						Main.dust[num2].velocity *= 0.25f;
					}
				}
			}
		}

		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			if (DetectPositives(projectile))
			{
				ECPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<ECPlayer>();
				if (!projectile.noEnchantments)
				{
					if (Main.rand.Next(4) == 0 && modPlayer.fireVial)
					{
						target.AddBuff(BuffID.OnFire, 180, false);
					}
					if (Main.rand.Next(4) == 0 && modPlayer.frostburnVial)
					{
						target.AddBuff(BuffID.Frostburn, 180, false);
					}
					if (Main.rand.Next(4) == 0 && modPlayer.poisonVial)
					{
						target.AddBuff(BuffID.Poisoned, 180, false);
					}
					if (Main.rand.Next(4) == 0 && modPlayer.midasVial)
					{
						target.AddBuff(BuffID.Midas, 600, false);
					}
					if (Main.rand.Next(4) == 0 && modPlayer.cursedFlamesVial)
					{
						target.AddBuff(BuffID.CursedInferno, 180, false);
					}
					if (Main.rand.Next(4) == 0 && modPlayer.ichorVial)
					{
						target.AddBuff(BuffID.Ichor, 300, false);
					}
					if (Main.rand.Next(4) == 0 && modPlayer.shadowflameVial) //Umbrakinesis
					{
						target.AddBuff(BuffID.ShadowFlame, 180, false);
					}
					if (Main.rand.Next(4) == 0 && modPlayer.venomVial)
					{
						target.AddBuff(BuffID.Venom, 180, false);
					}
				}
			}
		}

		public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (DetectPositives(projectile))
			{
				float critChance = Main.player[projectile.owner].GetModPlayer<ECPlayer>().tkCrit;
				crit = Main.rand.Next(1, 101) <= critChance;
			}
		}

		public bool DetectPositives(Projectile projectile)
		{
			if (projectile.type == ProjectileID.FlyingKnife)
			{
				return true;
			}

			List<int> TKProjectile = EsperClass.TKProjectile;
			foreach (var IsTKProjectile in EsperClass.TKProjectile)
			{
				if (projectile.type == IsTKProjectile)
					return true;
			}

			return false;
		}
	}

	public abstract class BaseSawbladeProj : ECProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 26;
			projectile.height = 26;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			maxVel = 16f;
			whizze = true;
			rotate = true;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.position -= projectile.velocity;
			if ((double)projectile.velocity.X != (double)oldVelocity.X)
				projectile.velocity.X = -oldVelocity.X;
			if ((double)projectile.velocity.Y != (double)oldVelocity.Y)
				projectile.velocity.Y = -oldVelocity.Y;
			return false;
		}
	}

	public abstract class BaseCanister : ECProjectile
	{
		int release = 0;
		protected int releaseRate = 15;
		protected int projType;
		protected float pourSpeed = 6f;

		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.DontAttachHideToAlpha[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			projectile.hide = true;
			projectile.noEnchantments = true;
			maxVel = 16f;
			whizze = false;
			rotate = false;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.position -= projectile.velocity;
			if ((double)projectile.velocity.X != (double)oldVelocity.X)
				projectile.velocity.X = -oldVelocity.X;
			if ((double)projectile.velocity.Y != (double)oldVelocity.Y)
				projectile.velocity.Y = -oldVelocity.Y;
			return false;
		}

		public override void PostAI()
		{
			if (!held)
			{
				return;
			}
			release += 1;
			if (release >= releaseRate)
			{
				release = 0;
				if (projectile.owner == Main.myPlayer)
				{
					Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
					Projectile.NewProjectile(vector.X, vector.Y, 0, pourSpeed, projType, (int)(projectile.damage), projectile.knockBack, Main.player[projectile.owner].whoAmI);
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

	public abstract class BaseCanisterProj : ECProjectile
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_406";
			}
		}

		protected int dustNum = 4;
		protected Color dustColor = new Color(255, 255, 255, 100);
		public bool doOnce = false;
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 10;
			projectile.height = 10;
			projectile.alpha = 255;
			projectile.penetrate = 1;
			projectile.extraUpdates = 2;
			projectile.ignoreWater = true;
			//projectile.localNPCHitCooldown = -1;
			//projectile.usesIDStaticNPCImmunity = true;
		}

		public override void AI()
		{
			ExtraAI();
			projectile.ai[0]++;
			for (int i = 0; i < 6; i++)
			{
				Vector2 vector45 = projectile.velocity * (float)i / 6f;
				int num594 = 6;
				int num595 = Dust.NewDust(projectile.position + Vector2.One * 6f, projectile.width - num594 * 2, projectile.height - num594 * 2, dustNum, 0f, 0f, 175, dustColor, 1.2f);
				Dust dust3;
				if (Main.rand.Next(2) == 0)
				{
					dust3 = Main.dust[num595];
					dust3.alpha += 25;
				}
				if (Main.rand.Next(2) == 0)
				{
					dust3 = Main.dust[num595];
					dust3.alpha += 25;
				}
				if (Main.rand.Next(2) == 0)
				{
					dust3 = Main.dust[num595];
					dust3.alpha += 25;
				}
				Main.dust[num595].noGravity = true;
				dust3 = Main.dust[num595];
				dust3.velocity *= 0.3f;
				dust3 = Main.dust[num595];
				dust3.velocity += projectile.velocity * 0.5f;
				Main.dust[num595].position = projectile.Center;
				Dust dust78 = Main.dust[num595];
				dust78.position.X = dust78.position.X - vector45.X;
				Dust dust79 = Main.dust[num595];
				dust79.position.Y = dust79.position.Y - vector45.Y;
				dust3 = Main.dust[num595];
				dust3.velocity *= 0.2f;
			}
			if (Main.rand.Next(4) == 0)
			{
				int num596 = 6;
				int num597 = Dust.NewDust(projectile.position + Vector2.One * 6f, projectile.width - num596 * 2, projectile.height - num596 * 2, dustNum, 0f, 0f, 175, dustColor, 1.2f);
				Dust dust3 = Main.dust[num597];
				dust3.velocity *= 0.5f;
				dust3 = Main.dust[num597];
				dust3.velocity += projectile.velocity * 0.5f;
				return;
			}
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (projectile.ai[0] < 2)
				damage /= 2;
			base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
		}
	}

	public abstract class BaseRiftProj : ECProjectile
	{
		protected int fireTimer = 0;
		protected int fireDelay = 39;
		protected int projType;
		protected float fireVel = 12f;

		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.DontAttachHideToAlpha[projectile.type] = true; // projectiles with hide but without this will draw in the lighting values of the owner player.
		}

		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 36;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			projectile.hide = true;
			projectile.noEnchantments = true;
			maxVel = 12f;
			whizze = false;
			rotate = false;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			bool flag13 = false;
			if (projectile.velocity.X != oldVelocity.X)
			{
				flag13 = true;
				projectile.velocity.X = oldVelocity.X * -1f;
			}
			if (projectile.velocity.Y != oldVelocity.Y)
			{
				flag13 = true;
				projectile.velocity.Y = oldVelocity.Y * -1f;
			}
			if (flag13)
			{
				Vector2 vector3 = Main.player[projectile.owner].Center - projectile.Center;
				vector3.Normalize();
				vector3 *= projectile.velocity.Length();
				vector3 *= 0.25f;
				projectile.velocity *= 0.75f;
				projectile.velocity += vector3;
				if (projectile.velocity.Length() > 6f)
				{
					projectile.velocity *= 0.5f;
				}
			}
			return false;
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 18;
			height = 18;
			return true;
		}

		public override void PostAI()
		{
			if (!held)
			{
				return;
			}
			projectile.rotation = -0.785f;
			fireTimer += 1;
			if (fireTimer >= fireDelay)
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
							//targetDist = distance;
							targetPos = npc.Center;
							target = true;
						}
					}
				}
				if (target)
				{
					/*if ((targetPos - projectile.Center).X > 0f)
					{
						projectile.spriteDirection = (projectile.direction = -1);
					}
					else if ((targetPos - projectile.Center).X < 0f)
					{
						projectile.spriteDirection = (projectile.direction = 1);
					}*/
					if (Main.myPlayer == projectile.owner)
					{
						Vector2 shootVel = targetPos - projectile.Center;
						if (shootVel == Vector2.Zero)
						{
							shootVel = new Vector2(0f, 1f);
						}
						shootVel.Normalize();
						shootVel *= fireVel;
						Main.PlaySound(SoundID.Item43, (int)projectile.position.X, (int)projectile.position.Y);
						int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootVel.X, shootVel.Y, projType, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
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
						//Main.projectile[proj].timeLeft = 300;
						//Main.projectile[proj].netUpdate = true;
						//projectile.netUpdate = true;
					}
				}
			}
		}

		/*public int GetTarget(float maxRange)
		{
			int first = -1;
			for (int j = 0; j < 200; j++)
			{
				NPC nPC = Main.npc[j];
				if (nPC.CanBeChasedBy(this, true))
				{
					float distance2 = Vector2.Distance(projectile.Center, nPC.Center);
					if (distance2 <= maxRange)
					{
						Vector2 vector2 = (nPC.Center - projectile.Center).SafeNormalize(Vector2.UnitY);
						if ((Math.Abs(vector2.X) >= Math.Abs(vector2.Y) || vector2.Y <= 0f) && (first == -1 || distance2 < Vector2.Distance(projectile.Center, Main.npc[first].Center)) && Collision.CanHitLine(projectile.Center, 0, 0, nPC.Center, 0, 0))
						{
							first = j;
						}
					}
				}
			}
			return first;
		}*/

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

	public abstract class BaseRiftBolt : ECProjectile
	{
		protected int dustType;

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 10;
			projectile.height = 10;
			projectile.alpha = 255;
			projectile.penetrate = 1;
			dustType = 86;
		}

		public override bool PreKill(int timeLeft)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
			int num3;
			for (int num507 = 0; num507 < 15; num507 = num3 + 1)
			{
				int num508 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustType, projectile.oldVelocity.X, projectile.oldVelocity.Y, 50, default(Color), 1.2f);
				Main.dust[num508].noGravity = true;
				Dust dust = Main.dust[num508];
				dust.scale *= 1.25f;
				dust = Main.dust[num508];
				dust.velocity *= 0.5f;
				num3 = num507;
			}
			return true;
		}

		public override void AI()
		{
			ExtraAI();
			if (dustType >= 0)
			{
				for (int i = 0; i < 2; i++)
				{
					int num345 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustType, projectile.velocity.X, projectile.velocity.Y, 50, default(Color), 1.2f);
					Main.dust[num345].noGravity = true;
					Dust dust3 = Main.dust[num345];
					dust3.velocity *= 0.3f;
				}
			}
			if (projectile.ai[1] == 0f)
			{
				projectile.ai[1] = 1f;
				Main.PlaySound(SoundID.Item8, projectile.position);
				return;
			}
		}
	}

	public abstract class BaseBoulderProj : ECProjectile
	{
		protected bool touched = false;

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			maxVel = 8f;
			whizze = false;
			canReturn = false;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			touched = true;
			if (held)
				return true;
			else
			{
				if ((projectile.velocity.X != oldVelocity.X && (oldVelocity.X < -3f || oldVelocity.X > 3f)) || (projectile.velocity.Y != oldVelocity.Y && (oldVelocity.Y < -3f || oldVelocity.Y > 3f)))
				{
					Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
					Main.PlaySound(0, (int)projectile.Center.X, (int)projectile.Center.Y, 1, 1f, 0f);
				}
				return false;
			}
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = held;
			return true;
		}

		public override void ExtraAI()
		{
			if (!held)
			{
				projectile.ai[0] += 1f;
				if (projectile.ai[0] > 15f)
				{
					projectile.ai[0] = 15f;
					if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
					{
						projectile.velocity.X = projectile.velocity.X * 0.97f;
						if ((double)projectile.velocity.X > -0.01 && (double)projectile.velocity.X < 0.01 && touched)
						{
							projectile.Kill();
						}
					}
					else if (projectile.velocity.X == 0f && touched)
					{
						projectile.Kill();
					}
					projectile.velocity.Y = projectile.velocity.Y + 0.2f;
				}
				projectile.rotation += projectile.velocity.X * 0.05f;
			}
			base.ExtraAI();
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			float damageScale = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
			if (damageScale < 1f)
				damageScale = 1f;
			damage = (int)((float)damage * damageScale / maxVel);
			base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
		}

		public override void Kill(int timeLeft)
		{
			if (held)
				Main.player[projectile.owner].channel = false;
		}
	}

	public abstract class BaseJar : ECProjectile
	{
		int release = 0;
		bool ready = false;
		int shakeAmount = 0;
		int lastShakeDir = 0;
		int shakeDur = 0;
		int shakeReset = 0;
		bool shakeStart = false; //Don't start the shake count right as the projectile is spawn
		protected int releaseDelay = 30;
		protected int projType;

		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.DontAttachHideToAlpha[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			projectile.hide = true;
			projectile.noEnchantments = true;
			maxVel = 12f;
			whizze = false;
			rotate = false;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.position -= projectile.velocity;
			if ((double)projectile.velocity.X != (double)oldVelocity.X)
				projectile.velocity.X = -oldVelocity.X;
			if ((double)projectile.velocity.Y != (double)oldVelocity.Y)
				projectile.velocity.Y = -oldVelocity.Y;
			return false;
		}

		public override void PostAI()
		{
			if (!held)
			{
				return;
			}
			if (shakeStart)
			{
				if (projectile.velocity.Y >= 4)
				{
					if (lastShakeDir != 1)
					{
						lastShakeDir = 1;
						JarShake();
					}
				}
				if (projectile.velocity.Y <= -4)
				{
					if (lastShakeDir != -1)
					{
						lastShakeDir = -1;
						JarShake();
					}
				}
				if (shakeAmount >= 6)
				{
					shakeAmount = 0;
					ready = true;
					shakeDur = 300;
				}
			}
			else
			{
				if (projectile.velocity.Y > 0)
					lastShakeDir = 1;
				if (projectile.velocity.Y < 0)
					lastShakeDir = -1;
				shakeStart = true;
			}
			if (ready)
			{
				release++;
				shakeDur--;
				if (shakeDur <= 0)
				{
					ready = false;
					lastShakeDir = 0;
				}
			}
			if (shakeReset > 0)
			{
				shakeReset--;
				if (shakeReset <= 0)
				{
					shakeAmount = 0;
					lastShakeDir = 0;
				}
			}
			if (release >= releaseDelay && ready)
			{
				release = 0;
				if (projectile.owner == Main.myPlayer)
				{
					float speedX = (float)Main.rand.Next(-35, 36) * 0.02f;
					float speedY = (float)Main.rand.Next(-35, 36) * 0.02f;
					Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
					Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, projType, (int)(projectile.damage), projectile.knockBack, Main.player[projectile.owner].whoAmI);
				}
			}
		}

		public virtual void JarShake()
		{
			shakeReset = 60;
			shakeAmount++;
			Main.PlaySound(SoundID.Item7, projectile.position);
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

	public abstract class BaseJarProj : ECProjectile
	{
		protected bool chaseLiquid = false;

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 14;
			projectile.height = 24;
			projectile.penetrate = 3;
			Main.projFrames[projectile.type] = 2;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.velocity.X != oldVelocity.X)
			{
				projectile.velocity.X = 0f - oldVelocity.X;
			}
			if (projectile.velocity.Y != oldVelocity.Y)
			{
				projectile.velocity.Y = 0f - oldVelocity.Y;
			}
			return projectile.penetrate <= 0;
		}

		//Adapted from AI Style 36
		public override void AI()
		{
			ExtraAI();
			if (projectile.velocity.X > 0f)
			{
				projectile.spriteDirection = 1;
			}
			else if (projectile.velocity.X < 0f)
			{
				projectile.spriteDirection = -1;
			}
			projectile.rotation = projectile.velocity.X * 0.1f;
			float num1220 = projectile.position.X;
			float num1222 = projectile.position.Y;
			float num1224 = 100000f;
			bool flag145 = false;
			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 30f)
			{
				projectile.ai[0] = 30f;
				for (int num1225 = 0; num1225 < 200; num1225++)
				{
					if (Main.npc[num1225].CanBeChasedBy(this) && (!Main.npc[num1225].wet || chaseLiquid))
					{
						float num1237 = Main.npc[num1225].position.X + (float)(Main.npc[num1225].width / 2);
						float num1246 = Main.npc[num1225].position.Y + (float)(Main.npc[num1225].height / 2);
						float num1247 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num1237) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num1246);
						if (num1247 < 800f && num1247 < num1224 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num1225].position, Main.npc[num1225].width, Main.npc[num1225].height))
						{
							num1224 = num1247;
							num1220 = num1237;
							num1222 = num1246;
							flag145 = true;
						}
					}
				}
			}
			if (!flag145)
			{
				num1220 = projectile.position.X + (float)(projectile.width / 2) + projectile.velocity.X * 100f;
				num1222 = projectile.position.Y + (float)(projectile.height / 2) + projectile.velocity.Y * 100f;
			}
			float num1255 = 6f;
			float num1257 = 0.1f;
			Vector2 vector310 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
			float num1259 = num1220 - vector310.X;
			float num1262 = num1222 - vector310.Y;
			float num1263 = (float)Math.Sqrt(num1259 * num1259 + num1262 * num1262);
			num1263 = num1255 / num1263;
			num1259 *= num1263;
			num1262 *= num1263;
			if (projectile.velocity.X < num1259)
			{
				projectile.velocity.X = projectile.velocity.X + num1257;
				if (projectile.velocity.X < 0f && num1259 > 0f)
				{
					projectile.velocity.X = projectile.velocity.X + num1257 * 2f;
				}
			}
			else if (projectile.velocity.X > num1259)
			{
				projectile.velocity.X = projectile.velocity.X - num1257;
				if (projectile.velocity.X > 0f && num1259 < 0f)
				{
					projectile.velocity.X = projectile.velocity.X - num1257 * 2f;
				}
			}
			if (projectile.velocity.Y < num1262)
			{
				projectile.velocity.Y = projectile.velocity.Y + num1257;
				if (projectile.velocity.Y < 0f && num1262 > 0f)
				{
					projectile.velocity.Y = projectile.velocity.Y + num1257 * 2f;
				}
			}
			else if (projectile.velocity.Y > num1262)
			{
				projectile.velocity.Y = projectile.velocity.Y - num1257;
				if (projectile.velocity.Y > 0f && num1262 < 0f)
				{
					projectile.velocity.Y = projectile.velocity.Y - num1257 * 2f;
				}
			}
		}
	}

	public abstract class BaseTwirlerProj : ECProjectile
	{
		protected int dir = 1;
		protected int twirlerDust;
		protected float dustR;
		protected float dustG;
		protected float dustB;
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 34;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.coldDamage = true;
			maxVel = 16f;
			whizze = false;
			rotate = false;
			twirlerDust = 6;
			dustR = 1f;
			dustG = 0.95f;
			dustB = 0.8f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			//projectile.position -= projectile.velocity;
			if ((double)projectile.velocity.X != (double)oldVelocity.X)
				projectile.velocity.X = -Math.Sign(projectile.velocity.X);
			if ((double)projectile.velocity.Y != (double)oldVelocity.Y)
				projectile.velocity.Y = -Math.Sign(projectile.velocity.Y);
			return false;
		}

		public override void PostAI()
		{
			if (projectile.velocity.X != 0)
				dir = Math.Sign(projectile.velocity.X);
			projectile.rotation -= dir * 6;
			if (!projectile.wet && !projectile.lavaWet)
			{
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, twirlerDust, 0f, 0f, 100, default(Color), 1f);
				Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), dustR, dustG, dustB);
			}
		}
	}
}
