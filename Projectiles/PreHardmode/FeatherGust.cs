using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class FeatherGust : ECProjectile
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
