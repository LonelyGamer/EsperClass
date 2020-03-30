using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class BatJarProj : ECProjectile
	{
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 16;
			projectile.height = 10;
			projectile.aiStyle = 36;
			projectile.penetrate = 3;
			Main.projFrames[projectile.type] = 3;
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
		
		/*public override void AI()
		{
			if (type != 307 && wet && !honeyWet)
			{
				Kill();
			}
			if (alpha > 0)
			{
				alpha -= 50;
			}
			else
			{
				extraUpdates = 0;
			}
			if (alpha < 0)
			{
				alpha = 0;
			}
			if (type == 307)
			{
				rotation = (float)Math.Atan2(base.velocity.Y, base.velocity.X) - 1.57f;
				frameCounter++;
				if (frameCounter >= 6)
				{
					frame++;
					frameCounter = 0;
				}
				if (frame >= 2)
				{
					frame = 0;
				}
				for (int num1212 = 0; num1212 < 3; num1212++)
				{
					float num1215 = base.velocity.X / 3f * (float)num1212;
					float num1216 = base.velocity.Y / 3f * (float)num1212;
					int num1218 = Dust.NewDust(position, width, height, 184);
					Main.dust[num1218].position.X = base.Center.X - num1215;
					Main.dust[num1218].position.Y = base.Center.Y - num1216;
					Dust dust81 = Main.dust[num1218];
					dust81.velocity *= 0f;
					Main.dust[num1218].scale = 0.5f;
				}
			}
			else
			{
				if (type == 316)
				{
					if (base.velocity.X > 0f)
					{
						spriteDirection = -1;
					}
					else if (base.velocity.X < 0f)
					{
						spriteDirection = 1;
					}
				}
				else if (base.velocity.X > 0f)
				{
					spriteDirection = 1;
				}
				else if (base.velocity.X < 0f)
				{
					spriteDirection = -1;
				}
				rotation = base.velocity.X * 0.1f;
				frameCounter++;
				if (frameCounter >= 3)
				{
					frame++;
					frameCounter = 0;
				}
				if (frame >= 3)
				{
					frame = 0;
				}
			}
			float num1220 = position.X;
			float num1222 = position.Y;
			float num1224 = 100000f;
			bool flag145 = false;
			ai[0] += 1f;
			if (ai[0] > 30f)
			{
				ai[0] = 30f;
				for (int num1225 = 0; num1225 < 200; num1225++)
				{
					if (Main.npc[num1225].CanBeChasedBy(this) && (!Main.npc[num1225].wet || type == 307))
					{
						float num1237 = Main.npc[num1225].position.X + (float)(Main.npc[num1225].width / 2);
						float num1246 = Main.npc[num1225].position.Y + (float)(Main.npc[num1225].height / 2);
						float num1247 = Math.Abs(position.X + (float)(width / 2) - num1237) + Math.Abs(position.Y + (float)(height / 2) - num1246);
						if (num1247 < 800f && num1247 < num1224 && Collision.CanHit(position, width, height, Main.npc[num1225].position, Main.npc[num1225].width, Main.npc[num1225].height))
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
				num1220 = position.X + (float)(width / 2) + base.velocity.X * 100f;
				num1222 = position.Y + (float)(height / 2) + base.velocity.Y * 100f;
			}
			else if (type == 307)
			{
				friendly = true;
			}
			float num1255 = 6f;
			float num1257 = 0.1f;
			if (type == 189)
			{
				num1255 = 7f;
				num1257 = 0.15f;
			}
			if (type == 307)
			{
				num1255 = 9f;
				num1257 = 0.2f;
			}
			if (type == 316)
			{
				num1255 = 10f;
				num1257 = 0.25f;
			}
			if (type == 566)
			{
				num1255 = 6.8f;
				num1257 = 0.14f;
			}
			Vector2 vector310 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
			float num1259 = num1220 - vector310.X;
			float num1262 = num1222 - vector310.Y;
			float num1263 = (float)Math.Sqrt(num1259 * num1259 + num1262 * num1262);
			num1263 = num1255 / num1263;
			num1259 *= num1263;
			num1262 *= num1263;
			if (base.velocity.X < num1259)
			{
				base.velocity.X = base.velocity.X + num1257;
				if (base.velocity.X < 0f && num1259 > 0f)
				{
					base.velocity.X = base.velocity.X + num1257 * 2f;
				}
			}
			else if (base.velocity.X > num1259)
			{
				base.velocity.X = base.velocity.X - num1257;
				if (base.velocity.X > 0f && num1259 < 0f)
				{
					base.velocity.X = base.velocity.X - num1257 * 2f;
				}
			}
			if (base.velocity.Y < num1262)
			{
				base.velocity.Y = base.velocity.Y + num1257;
				if (base.velocity.Y < 0f && num1262 > 0f)
				{
					base.velocity.Y = base.velocity.Y + num1257 * 2f;
				}
			}
			else if (base.velocity.Y > num1262)
			{
				base.velocity.Y = base.velocity.Y - num1257;
				if (base.velocity.Y > 0f && num1262 < 0f)
				{
					base.velocity.Y = base.velocity.Y - num1257 * 2f;
				}
			}
		}*/

		public override void ExtraAI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 7)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame > 2)
				{
					projectile.frame = 0;
				}
			}
			base.ExtraAI();
		}

		public override void AI()
		{
			ExtraAI();
		}
	}
}
