using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class TKPrimeLaserProj : ECProjectile
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_100";
			}
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 4;
			projectile.height = 4;
			projectile.light = 0.75f;
			//projectile.alpha = 64;
			projectile.extraUpdates = 2;
			projectile.scale = 1.8f;
			projectile.timeLeft = 2700;
			projectile.penetrate = 10;
			projectile.localNPCHitCooldown = -1;
			projectile.usesLocalNPCImmunity = true;
		}

		public override Color? GetAlpha(Color lightColor) => new Color(255, 127, 0, 0);

		public override bool PreKill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, projectile.position);
			return true;
		}

		public override void AI()
		{
			ExtraAI();
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 1.57f;
			Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), 1f, 0.5f, 0f);
		}
	}
}
