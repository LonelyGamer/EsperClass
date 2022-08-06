using Microsoft.Xna.Framework;
using Terraria;

namespace EsperClass.Projectiles.PostMoonLord.CrossMod
{
    public class MiniCactuar : BaseSawbladeProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 46;
			projectile.height = 54;
			maxVel = 24f;
			projectile.localNPCHitCooldown = 10;
			projectile.usesLocalNPCImmunity = true;
		}

		public override void PostAI()
		{
			if (held)
			{
				Vector2 shootVel = new Vector2(32, 32).RotatedByRandom(MathHelper.ToRadians(360));
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootVel.X, shootVel.Y, mod.ProjectileType("JoostNeedle"), projectile.damage, 0, Main.myPlayer, 0f, 0f);
			}
		}
	}
}
