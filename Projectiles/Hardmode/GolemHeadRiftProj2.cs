using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class GolemHeadRiftProj2 : ECProjectile
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_258";
			}
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.aiStyle = 8;
			//aiType = ProjectileID.Fireball;
			projectile.width = 16;
			projectile.height = 16;
			projectile.alpha = 100;
			projectile.timeLeft = 300;
			projectile.penetrate = -1;
			projectile.localNPCHitCooldown = 10;
			projectile.usesLocalNPCImmunity = true;
		}

		public override Color? GetAlpha(Color lightColor) => new Color(200, 200, 200, 25);

		/*public override bool PreKill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, projectile.position);
			return true;
		}*/

		public override void AI()
		{
			ExtraAI();
			//projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 1.57f;
			Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), 0.78f, 0.78f, 0.78f);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 300, false);
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
