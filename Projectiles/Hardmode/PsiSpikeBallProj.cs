using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class PsiSpikeBallProj : ECProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 36;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.localNPCHitCooldown = 30;
			projectile.usesLocalNPCImmunity = true;
		}

		public override void AI()
		{
			ExtraAI();
			projectile.timeLeft++;
			if (Main.projectile[(int)projectile.ai[0]].active)
			{
			 	projectile.ai[1] += 8f * Main.projectile[(int)projectile.ai[0]].spriteDirection;
				float vX = 64 * (float)Math.Cos(projectile.ai[1] / 180 * Math.PI);
				float vY = 64 * (float)Math.Sin(projectile.ai[1] / 180 * Math.PI);
				projectile.position = Main.projectile[(int)projectile.ai[0]].Center - projectile.Size / 2f;
				projectile.velocity.X = vX;
				projectile.velocity.Y = vY;
			}
			else
			{
				projectile.Kill();
				return;
			}
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (projectile.velocity.X != 0)
				hitDirection = Math.Sign(projectile.velocity.X);
			base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
		}

		public override bool PreDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 orbitCenter = Main.projectile[(int)projectile.ai[0]].Center;
			Vector2 center = projectile.Center;
			Vector2 distToProj = orbitCenter - projectile.Center;
			float projRotation = distToProj.ToRotation() - 1.57f;
			float distance = distToProj.Length();
			while (distance > 6f && !float.IsNaN(distance))
			{
				distToProj.Normalize();
				distToProj *= 6f;
				center += distToProj;
				distToProj = orbitCenter - center;
				distance = distToProj.Length();
				Color drawColor = lightColor;
				spriteBatch.Draw(mod.GetTexture("Projectiles/Hardmode/PsiSpikeBallChain"), new Vector2(center.X - Main.screenPosition.X, center.Y - Main.screenPosition.Y), new Rectangle(0, 0, 6, 12), drawColor, projRotation, new Vector2(3, 6), 1f, SpriteEffects.None, 0f);
			}
			return true;
		}
	}
}
