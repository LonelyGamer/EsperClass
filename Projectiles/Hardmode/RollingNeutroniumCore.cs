using Microsoft.Xna.Framework;
using Terraria;

namespace EsperClass.Projectiles.Hardmode
{
	public class RollingNeutroniumCore : ECProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 28;
			projectile.height = 20;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			projectile.noEnchantments = true;
			maxVel = 20f;
			whizze = false;
			canReturn = false;
			Main.projFrames[projectile.type] = 4;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}

		public override void ExtraAI()
		{
			if (!held)
			{
				projectile.velocity = Vector2.Zero;
				projectile.frameCounter++;
				if (projectile.frameCounter > 3)
				{
					projectile.frameCounter = 0;
					projectile.frame++;
					if (projectile.frame >= 3 && projectile.localAI[1] != 1)
					{
						projectile.localAI[1] = 1;
						projectile.timeLeft = 3;
						Projectile.NewProjectile(projectile.position, Vector2.Zero, mod.ProjectileType("RollingNeutroniumCoreExplosion"), (int)(projectile.damage), projectile.knockBack, Main.player[projectile.owner].whoAmI);
						int proj = Projectile.NewProjectile(projectile.position, Vector2.Zero, mod.ProjectileType("RollingNeutroniumCoreExplosionFx"), 0, 0, Main.player[projectile.owner].whoAmI);
						Main.projectile[proj].position.X += 16;
						Main.projectile[proj].position.Y += 20;
						Main.projectile[proj].rotation = Main.rand.NextFloat(3.14f);
						/*int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("RollingNeutroniumCoreExplosion"));
						Main.dust[dust].position = projectile.position;
						Main.dust[dust].position.X -= 36;
						Main.dust[dust].position.Y -= 60;
						Main.dust[dust].rotation = Main.rand.NextFloat(3.14f);*/
					}
				}
			}
			base.ExtraAI();
		}

		public override bool? CanCutTiles()
		{
			return false;
		}

		public override bool? CanHitNPC(NPC npc)
		{
			return false;
		}

		public override void Kill(int timeLeft)
		{
			if (held)
				Main.player[projectile.owner].channel = false;
			base.Kill(timeLeft);
		}
	}
}
