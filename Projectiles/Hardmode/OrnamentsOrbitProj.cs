using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class OrnamentsOrbitProj : ECProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 26;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			Main.projFrames[projectile.type] = 6;
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
	}
}
