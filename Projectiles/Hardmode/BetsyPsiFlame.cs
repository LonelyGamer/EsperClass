using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class BetsyPsiFlame : ECProjectile
	{
		public override string Texture => "Terraria/Projectile_687";

		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 7;
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 30;
			projectile.height = 30;
			projectile.penetrate = -1;
			projectile.alpha = 255;
			projectile.timeLeft = 30;
			projectile.localNPCHitCooldown = -1;
			projectile.usesLocalNPCImmunity = true;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 value57 = projectile.Center;
			value57 -= Main.screenPosition;
			float num636 = 40f;
			float num635 = num636 * 2f;
			float num634 = (float)projectile.frameCounter / num636;
			Texture2D texture2D52 = Main.projectileTexture[projectile.type];
			Color color91 = Color.Transparent;
			Color color90 = new Color(255, 255, 255, 0);
			Color color89 = new Color(180, 30, 30, 200);
			Color color88 = new Color(0, 0, 0, 30);
			ulong num633 = 1uL;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
			for (float num632 = 0f; num632 < 15f; num632 += 1f)
			{
				float num631 = Utils.RandomFloat(ref num633) * 0.25f - 0.125f;
				Vector2 value56 = (projectile.rotation + num631).ToRotationVector2();
				Vector2 value55 = value57 + value56 * 400f;
				float num630 = num634 + num632 * (71f / (339f * (float)Math.PI));
				int num629 = (int)(num630 / (71f / (339f * (float)Math.PI)));
				num630 %= 1f;
				if ((num630 <= num634 % 1f || (float)projectile.frameCounter >= num636) && (num630 >= num634 % 1f || (float)projectile.frameCounter < num635 - num636))
				{
					color91 = ((num630 < 0.1f) ? Color.Lerp(Color.Transparent, color90, Utils.InverseLerp(0f, 0.1f, num630, clamped: true)) : ((num630 < 0.35f) ? color90 : ((num630 < 0.7f) ? Color.Lerp(color90, color89, Utils.InverseLerp(0.35f, 0.7f, num630, clamped: true)) : ((num630 < 0.9f) ? Color.Lerp(color89, color88, Utils.InverseLerp(0.7f, 0.9f, num630, clamped: true)) : ((!(num630 < 1f)) ? Color.Transparent : Color.Lerp(color88, Color.Transparent, Utils.InverseLerp(0.9f, 1f, num630, clamped: true)))))));
					float num627 = 0.9f + num630 * 0.8f;
					num627 *= num627;
					num627 *= 0.8f;
					Vector2 position33 = Vector2.SmoothStep(value57, value55, num630);
					Rectangle rectangle16 = texture2D52.Frame(1, 7, 0, (int)(num630 * 7f));
					spriteBatch.Draw(texture2D52, position33, rectangle16, color91, projectile.rotation, rectangle16.Size() / 2f, num627, SpriteEffects.None, 0f);
				}
			}
			return true;
		}

        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            hitbox = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, 30 + (166 * projectile.frame / 7), 30 + (166 * projectile.frame / 7));
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			float num9 = 0f;
			float num8 = projectile.ai[0] / 25f;
			float range = 400f;
			if (num8 > 1f)
			{
				num8 = 1f;
			}
			float num7 = (projectile.ai[0] - 38f) / 40f;
			if (num7 < 0f)
			{
				num7 = 0f;
			}
			Vector2 lineStart = projectile.Center + projectile.rotation.ToRotationVector2() * range * num7;
			Vector2 lineEnd = projectile.Center + projectile.rotation.ToRotationVector2() * range * num8;
			if (Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), lineStart, lineEnd, 40f * projectile.scale, ref num9))
			{
				return true;
			}
			return false;
		}

		public override bool PreAI()
		{
			Projectile parentProj = Main.projectile[(int)projectile.ai[1]];
			projectile.Center = parentProj.Center;
			return true;
		}

		//Adepted from aiStyle 136
		public override void AI()
		{
			ExtraAI();
			float range = 400f;
			float range2 = 16f;
			DelegateMethods.v3_1 = new Vector3(1.2f, 1f, 0.3f);
			float num6 = projectile.ai[0] / 40f;
			if (num6 > 1f)
			{
				num6 = 1f;
			}
			float num7 = (projectile.ai[0] - 38f) / 40f;
			if (num7 < 0f)
			{
				num7 = 0f;
			}
			Utils.PlotTileLine(projectile.Center + projectile.rotation.ToRotationVector2() * range * num7, projectile.Center + projectile.rotation.ToRotationVector2() * range * num6, range2, DelegateMethods.CastLight);
			Utils.PlotTileLine(projectile.Center + projectile.rotation.ToRotationVector2().RotatedBy(0.19634954631328583) * range * num7, projectile.Center + projectile.rotation.ToRotationVector2().RotatedBy(0.19634954631328583) * range * num6, range2, DelegateMethods.CastLight);
			Utils.PlotTileLine(projectile.Center + projectile.rotation.ToRotationVector2().RotatedBy(-0.19634954631328583) * range * num7, projectile.Center + projectile.rotation.ToRotationVector2().RotatedBy(-0.19634954631328583) * range * num6, range2, DelegateMethods.CastLight);
			if (num7 == 0f && num6 > 0.1f)
			{
				for (int j = 0; j < 3; j++)
				{
					Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6);
					dust.fadeIn = 1.5f;
					dust.velocity = projectile.rotation.ToRotationVector2().RotatedBy(Main.rand.NextFloatDirection() * ((float)Math.PI / 12f)) * (0.5f + Main.rand.NextFloat() * 2.5f) * 15f;
					dust.noLight = true;
					dust.noGravity = true;
					dust.alpha = 200;
				}
			}
			if (Main.rand.Next(5) == 0 && projectile.ai[0] >= 15f)
			{
				Gore gore = Gore.NewGoreDirect(projectile.Center + projectile.rotation.ToRotationVector2() * 300f - Utils.RandomVector2(Main.rand, -20f, 20f), Vector2.Zero, 61 + Main.rand.Next(3), 0.5f);
				gore.velocity *= 0.3f;
				gore.velocity += projectile.rotation.ToRotationVector2() * 4f;
			}
			for (int i = 0; i < 1; i++)
			{
				Dust dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 31);
				dust2.fadeIn = 1.5f;
				dust2.scale = 0.4f;
				dust2.velocity = projectile.rotation.ToRotationVector2().RotatedBy(Main.rand.NextFloatDirection() * ((float)Math.PI / 12f)) * (0.5f + Main.rand.NextFloat() * 2.5f) * 15f;
				dust2.velocity *= 0.3f;
				dust2.noLight = true;
				dust2.noGravity = true;
				float num4 = Main.rand.NextFloat();
				dust2.position = Vector2.Lerp(projectile.Center + projectile.rotation.ToRotationVector2() * range * num7, projectile.Center + projectile.rotation.ToRotationVector2() * range * num6, num4);
				dust2.position += projectile.rotation.ToRotationVector2().RotatedBy(1.5707963705062866) * (20f + 100f * (num4 - 0.5f));
			}
			projectile.frameCounter++;
			projectile.ai[0]++;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 600, false);
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
