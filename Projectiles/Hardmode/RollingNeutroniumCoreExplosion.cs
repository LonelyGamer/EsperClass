using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
    //This is copied over from LootBag's EpicExplosion
    public class RollingNeutroniumCoreExplosion : ECProjectile
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_0";
			}
		}

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rolling Neutronium Core Explosion");
        }

        public override void SetDefaults()
        {
            projectile.width = 80;
            projectile.height = 80;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 5;
			projectile.alpha = 255;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
			ExtraAI();
			Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), 1f, 0f, 0.7f);
			if (projectile.timeLeft == 5)
				Explosion();
			/*Dust dust;
            Vector2 position = projectile.position + projectile.velocity;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 27, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
            dust.scale = 2;*/
		}

		public override void OnHitNPC(NPC npc, int damage, float knockback, bool crit)
		{
			npc.AddBuff(mod.BuffType("Irradiated"), 300, false);
			base.OnHitNPC(npc, damage, knockback, crit);
		}

		public void Explosion()
		{
			Main.PlaySound(SoundLoader.customSoundType, projectile.position, mod.GetSoundSlot(SoundType.Custom, "Sounds/DemonCoreExplosion"));
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 256;
			projectile.height = 256;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			for (int i = 0; i < 20; i++)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
				Main.dust[dust].velocity.X = (12 + Main.rand.Next(-4, 4));
				if (Main.rand.Next(2) == 0)
					Main.dust[dust].velocity.X *= -1;
				Main.dust[dust].velocity.Y = 0;
			}
			for (int i = 0; i < 10; i++)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2.5f);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity.X = (12 + Main.rand.Next(-4, 4));
				if (Main.rand.Next(2) == 0)
					Main.dust[dust].velocity.X *= -1;
				Main.dust[dust].velocity.Y = 0;
				dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 45, 0f, 0f, 100, default(Color), 1.5f);
				Main.dust[dust].velocity.X = (12 + Main.rand.Next(-4, 4));
				if (Main.rand.Next(2) == 0)
					Main.dust[dust].velocity.X *= -1;
				Main.dust[dust].velocity.Y = 0;
			}
			/*int num635 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64));
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
			expr_11BE6_cp_0.velocity.Y = expr_11BE6_cp_0.velocity.Y - 1f;*/
		}
	}
}
