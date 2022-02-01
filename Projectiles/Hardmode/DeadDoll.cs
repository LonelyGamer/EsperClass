using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class DeadDoll : BaseJar
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projType = mod.ProjectileType("DeadDollProj");
			projectile.width = 30;
			projectile.height = 52;
			releaseDelay = 6;
		}

		public override void Fire()
		{
			float speedY = Main.rand.Next(6, 12);
			Vector2 vector = new Vector2(projectile.position.X + Main.rand.Next(0, projectile.width + 1), projectile.position.Y + (float)projectile.height * 0.5f);
			Projectile.NewProjectile(vector.X, vector.Y, 0, speedY, projType, (int)(projectile.damage), projectile.knockBack, Main.player[projectile.owner].whoAmI);
		}
	}
}
