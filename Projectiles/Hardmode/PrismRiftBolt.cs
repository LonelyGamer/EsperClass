using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class PrismRiftBolt : BaseRiftBolt
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_126";
			}
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.width = 10;
			projectile.height = 10;
			projectile.alpha = 255;
			projectile.penetrate = 10;
			dustType = 86;
		}

		public override void ExtraAI()
		{
			int[] randomDust = { 86, 87, 88, 89, 90, 91, 262 };
			dustType = Main.rand.Next(randomDust.Length);
			Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), (float)Main.DiscoR / 255f, (float)Main.DiscoG / 255f, (float)Main.DiscoB / 255f);
			base.ExtraAI();
		}
	}
}
