using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class TKPrimeCannonProj : ECProjectile
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_102";
			}
		}

		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = 1;
			Main.projFrames[projectile.type] = 2;
		}

		public override Color? GetAlpha(Color lightColor) => new Color(200, 200, 200, 25);

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 5;
			base.OnHitNPC(target, damage, knockback, crit);
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.position.X + (float)(target.width / 2) < projectile.position.X + (float)(projectile.width / 2)) //(target.position.X < projectile.position.X + projectile.width * 0.5f)
				hitDirection = -1;
			else
				hitDirection = 1;
			base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
		}

		public override void AI()
		{
			ExtraAI();
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = false;
			return true;
		}

		public override void ExtraAI()
		{
			projectile.velocity.Y += 0.2f;
			if (projectile.velocity.Y > 10f)
			{
				projectile.velocity.Y = 10f;
			}
			if (projectile.localAI[0] == 0f)
			{
				projectile.localAI[0] = 1f;
				Main.PlaySound(SoundID.Item10, projectile.position);
			}
			projectile.frameCounter++;
			if (projectile.frameCounter > 3)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame > 1)
			{
				projectile.frame = 0;
			}
			if (projectile.velocity.Y == 0f)
			{
				projectile.position.X += (float)(projectile.width / 2);
				projectile.position.Y += (float)(projectile.height / 2);
				projectile.width = 128;
				projectile.height = 128;
				projectile.position.X -= (float)(projectile.width / 2);
				projectile.position.Y -= (float)(projectile.height / 2);
				projectile.timeLeft = 3;
				projectile.netUpdate = true;
			}
			base.ExtraAI();
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item14, projectile.position);
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 22;
			projectile.height = 22;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			for (int num220 = 0; num220 < 20; num220++)
			{
				int num211 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
				Dust dust24 = Main.dust[num211];
				dust24.velocity *= 1.4f;
			}
			for (int num219 = 0; num219 < 10; num219++)
			{
				int num214 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2.5f);
				Main.dust[num214].noGravity = true;
				Dust dust24 = Main.dust[num214];
				dust24.velocity *= 5f;
				num214 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
				dust24 = Main.dust[num214];
				dust24.velocity *= 3f;
			}
			int num218 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
			Gore gore2 = Main.gore[num218];
			gore2.velocity *= 0.4f;
			Gore expr_18B0E_cp_0 = Main.gore[num218];
			expr_18B0E_cp_0.velocity.X = expr_18B0E_cp_0.velocity.X + 1f;
			Gore expr_18B2E_cp_0 = Main.gore[num218];
			expr_18B2E_cp_0.velocity.Y = expr_18B2E_cp_0.velocity.Y + 1f;
			num218 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
			gore2 = Main.gore[num218];
			gore2.velocity *= 0.4f;
			Gore expr_18BB2_cp_0 = Main.gore[num218];
			expr_18BB2_cp_0.velocity.X = expr_18BB2_cp_0.velocity.X - 1f;
			Gore expr_18BD2_cp_0 = Main.gore[num218];
			expr_18BD2_cp_0.velocity.Y = expr_18BD2_cp_0.velocity.Y + 1f;
			num218 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
			gore2 = Main.gore[num218];
			gore2.velocity *= 0.4f;
			Gore expr_18C56_cp_0 = Main.gore[num218];
			expr_18C56_cp_0.velocity.X = expr_18C56_cp_0.velocity.X + 1f;
			Gore expr_18C76_cp_0 = Main.gore[num218];
			expr_18C76_cp_0.velocity.Y = expr_18C76_cp_0.velocity.Y - 1f;
			num218 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
			gore2 = Main.gore[num218];
			gore2.velocity *= 0.4f;
			Gore expr_18CFA_cp_0 = Main.gore[num218];
			expr_18CFA_cp_0.velocity.X = expr_18CFA_cp_0.velocity.X - 1f;
			Gore expr_18D1A_cp_0 = Main.gore[num218];
			expr_18D1A_cp_0.velocity.Y = expr_18D1A_cp_0.velocity.Y - 1f;
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 128;
			projectile.height = 128;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			if (projectile.owner == Main.myPlayer)
			{
				projectile.localAI[1] = -1f;
				projectile.maxPenetrate = 0;
				projectile.Damage();
			}
			base.Kill(timeLeft);
		}
	}
}
