using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class SpectreRiftBolt : BaseRiftBolt
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_297";
			}
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 12;
			projectile.height = 12;
			projectile.alpha = 255;
			projectile.penetrate = 10;
			projectile.localNPCHitCooldown = -1;
			projectile.usesLocalNPCImmunity = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 300;
			dustType = 175;
		}

		public override void ExtraAI()
		{
			for (int num1165 = 0; num1165 < 5; num1165++)
			{
				int num1163 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 175, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num1163].noGravity = true;
				Dust dust81 = Main.dust[num1163];
				dust81.velocity *= 0f;
			}
			base.ExtraAI();
		}
	}
}
