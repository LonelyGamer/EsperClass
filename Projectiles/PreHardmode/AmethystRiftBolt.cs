using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class AmethystRiftBolt : ECProjectile
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_121";
			}
		}

		protected int dustType;

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 10;
			projectile.height = 10;
			projectile.alpha = 255;
			projectile.penetrate = 1;
			dustType = 86;
		}

		public override bool PreKill(int timeLeft)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
			int num3;
			for (int num507 = 0; num507 < 15; num507 = num3 + 1)
			{
				int num508 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustType, projectile.oldVelocity.X, projectile.oldVelocity.Y, 50, default(Color), 1.2f);
				Main.dust[num508].noGravity = true;
				Dust dust = Main.dust[num508];
				dust.scale *= 1.25f;
				dust = Main.dust[num508];
				dust.velocity *= 0.5f;
				num3 = num507;
			}
			return true;
		}

		public override void AI()
		{
			ExtraAI();
			int num3;
			for (int i = 0; i < 2; i++)
			{
				int num345 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustType, projectile.velocity.X, projectile.velocity.Y, 50, default(Color), 1.2f);
				Main.dust[num345].noGravity = true;
				Dust dust3 = Main.dust[num345];
				dust3.velocity *= 0.3f;
			}
			if (projectile.ai[1] == 0f)
			{
				projectile.ai[1] = 1f;
				Main.PlaySound(SoundID.Item8, projectile.position);
				return;
			}
		}
	}
}
