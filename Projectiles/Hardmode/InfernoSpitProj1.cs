using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class InfernoSpitProj1 : ECProjectile
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_295";
			}
		}

		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 60;
			projectile.hide = true;
			projectile.noEnchantments = true;
		}

		public override bool? CanCutTiles()
		{
			return false;
		}

		public override bool? CanHitNPC(NPC npc)
		{
			return false;
		}

		public override void AI()
		{
			for (int i = 0; i < 8; i++)
			{
				int num1185 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 174, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num1185].noGravity = true;
				Dust dust81 = Main.dust[num1185];
				dust81.velocity *= 0.5f;
				dust81 = Main.dust[num1185];
				dust81.velocity += projectile.velocity * 0.1f;
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item74, projectile.position);
			if (projectile.owner == Main.myPlayer)
			{
				Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				Projectile.NewProjectile(vector.X, vector.Y, 0, 0, mod.ProjectileType("InfernoSpitProj2"), (int)(projectile.damage), projectile.knockBack, Main.player[projectile.owner].whoAmI);
			}
		}
	}
}
