using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Projectiles.Hardmode
{
	public class ForbiddenGust : ECProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			maxVel = 10f;
			whizze = false;
			rotate = false;
			Main.projFrames[projectile.type] = 6;
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

		public override void ExtraAI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 3)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame > 5)
				{
					projectile.frame = 0;
				}
			}
			if (Main.rand.Next(2) == 0)
			{
				int num425 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 32);
				Dust expr_5C63_cp_0 = Main.dust[num425];
				expr_5C63_cp_0.velocity.X = expr_5C63_cp_0.velocity.X * 0.4f;
			}
			base.ExtraAI();
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.knockBackResist > 0f)
			{
				float realKB = knockback;
				knockback *= 0.1f;
				if (!target.noGravity)
					target.velocity.Y = -realKB;
				else
					target.velocity.Y = realKB;
			}
			base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
		}
	}
}
