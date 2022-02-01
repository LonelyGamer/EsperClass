using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class GolemHeadRift : BaseRiftProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projType = mod.ProjectileType("GolemHeadRiftProj1");
			fireDelay = 30;
			fireVel = 24f;
			angled = false;
			targetDist = 600f;
		}

		public override void Fire(Vector2 speed, int target)
		{
			Main.PlaySound(SoundID.Item33, (int)projectile.position.X, (int)projectile.position.Y);
			Vector2 speed2 = speed * 0.75f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, speed.X, speed.Y, projType, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
			Main.PlaySound(SoundID.Item20, (int)projectile.position.X, (int)projectile.position.Y);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, speed2.X, speed2.Y, mod.ProjectileType("GolemHeadRiftProj2"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
			/*Vector2 vector220 = new Vector2(base.Center.X, base.Center.Y + 10f);
			float num1604 = 8f;
			float num1603 = Main.player[target].position.X + (float)Main.player[target].width * 0.5f - vector220.X;
			float num1602 = Main.player[target].position.Y + (float)Main.player[target].height * 0.5f - vector220.Y;
			float num1601 = (float)Math.Sqrt(num1603 * num1603 + num1602 * num1602);
			num1601 = num1604 / num1601;
			num1603 *= num1601;
			num1602 *= num1601;
			int num1597 = 18;
			int num1596 = 258;
			if (Main.netMode != 1)
			{
				Projectile.NewProjectile(vector220.X, vector220.Y, num1603, num1602, num1596, num1597, 0f, Main.myPlayer);
			}*/
		}
	}
}
