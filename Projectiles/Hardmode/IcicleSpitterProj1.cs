using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class IcicleSpitterProj1 : ECProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
			projectile.friendly = true;
			projectile.penetrate = 5;
			projectile.localNPCHitCooldown = -1;
			projectile.usesLocalNPCImmunity = true;
			projectile.coldDamage = true;
			Main.projFrames[projectile.type] = 5;
			projectile.timeLeft = 180;
		}

		public override Color? GetAlpha(Color lightColor) => new Color(200, 200, 200, 0);

		public override void AI()
		{
			ExtraAI();
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
		}

		public override bool PreKill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item27, projectile.position);
			return true;
		}

		public override void Kill(int timeLeft)
		{
			for (int num829 = 0; num829 < 3; num829++)
			{
				int num827 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 76);
				Main.dust[num827].noGravity = true;
				Main.dust[num827].noLight = true;
				Main.dust[num827].scale = 0.7f;
			}
			base.Kill(timeLeft);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 180, false);
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
