using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class IcicleSpitterProj2 : ECProjectile
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_348";
			}
		}

		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
			projectile.friendly = true;
			projectile.penetrate = -1;
			//projectile.tileCollide = false;
			projectile.localNPCHitCooldown = -1;
			projectile.usesLocalNPCImmunity = true;
			projectile.coldDamage = true;
			projectile.timeLeft = 180;
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 12;
			height = 12;
			return true;
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
			for (int num829 = 0; num829 < 10; num829++)
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
			target.AddBuff(BuffID.Frostburn, 300, false);
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
