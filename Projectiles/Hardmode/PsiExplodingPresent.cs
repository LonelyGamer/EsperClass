using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class PsiExplodingPresent : BaseBoulderProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 26;
			projectile.height = 34;
			Main.projFrames[projectile.type] = 4;
			projectile.penetrate = 1;
			maxVel = 16f;
			projectile.timeLeft = 180;
			noDamageScale = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 5;
			base.OnHitNPC(target, damage, knockback, crit);
		}

		public override void ExtraAI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 3)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame > 3)
				{
					projectile.frame = 0;
				}
			}
			base.ExtraAI();
		}

		public override void Kill(int timeLeft)
		{
			if (held)
				Main.player[projectile.owner].channel = false;
			Main.PlaySound(SoundID.Item14, projectile.position);
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 256;
			projectile.height = 256;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			if (projectile.owner == Main.myPlayer)
			{
				projectile.localAI[1] = -1f;
				projectile.maxPenetrate = 0;
				projectile.Damage();
			}
			for (int num637 = 0; num637 < 20; num637++)
			{
				int num625 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
				Dust dust24 = Main.dust[num625];
				dust24.velocity *= 1.4f;
			}
			for (int num636 = 0; num636 < 10; num636++)
			{
				int num629 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2.5f);
				Main.dust[num629].noGravity = true;
				Dust dust24 = Main.dust[num629];
				dust24.velocity *= 5f;
				num629 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
				dust24 = Main.dust[num629];
				dust24.velocity *= 3f;
			}
			int num635 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
			Gore gore2 = Main.gore[num635];
			gore2.velocity *= 0.4f;
			Gore expr_119DA_cp_0 = Main.gore[num635];
			expr_119DA_cp_0.velocity.X = expr_119DA_cp_0.velocity.X + 1f;
			Gore expr_119FA_cp_0 = Main.gore[num635];
			expr_119FA_cp_0.velocity.Y = expr_119FA_cp_0.velocity.Y + 1f;
			num635 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
			gore2 = Main.gore[num635];
			gore2.velocity *= 0.4f;
			Gore expr_11A7E_cp_0 = Main.gore[num635];
			expr_11A7E_cp_0.velocity.X = expr_11A7E_cp_0.velocity.X - 1f;
			Gore expr_11A9E_cp_0 = Main.gore[num635];
			expr_11A9E_cp_0.velocity.Y = expr_11A9E_cp_0.velocity.Y + 1f;
			num635 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
			gore2 = Main.gore[num635];
			gore2.velocity *= 0.4f;
			Gore expr_11B22_cp_0 = Main.gore[num635];
			expr_11B22_cp_0.velocity.X = expr_11B22_cp_0.velocity.X + 1f;
			Gore expr_11B42_cp_0 = Main.gore[num635];
			expr_11B42_cp_0.velocity.Y = expr_11B42_cp_0.velocity.Y - 1f;
			num635 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
			gore2 = Main.gore[num635];
			gore2.velocity *= 0.4f;
			Gore expr_11BC6_cp_0 = Main.gore[num635];
			expr_11BC6_cp_0.velocity.X = expr_11BC6_cp_0.velocity.X - 1f;
			Gore expr_11BE6_cp_0 = Main.gore[num635];
			expr_11BE6_cp_0.velocity.Y = expr_11BE6_cp_0.velocity.Y - 1f;
			base.Kill(timeLeft);
		}
	}
}
