using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class MoltenBoulder : BaseBoulderProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.penetrate = 10;
			maxVel = 12f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 180, false);
			base.OnHitNPC(target, damage, knockback, crit);
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 0, default(Color), 1f);
			}
			base.Kill(timeLeft);
		}
	}
}
