using Microsoft.Xna.Framework;
using Terraria;

namespace EsperClass.Projectiles.PostMoonLord
{
    public class AccretionDisc : BaseSawbladeProj
	{
		int auraRadius = 64;
		int auraDelay;
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 36;
			projectile.height = 36;
			projectile.localNPCHitCooldown = 5;
			projectile.usesLocalNPCImmunity = true;
			maxVel = 24f;
		}

		public override void PostAI()
		{
			int[] randomDust = { 86, 87, 88, 89, 90, 91, 262 };
			auraDelay++;
			if (auraRadius < 384 && auraDelay >= 3)
			{
				auraRadius += 2;
				auraDelay = 0;
			}
			for (int i = 0; i < 60; i++)
			{
				int dustType = Main.rand.Next(randomDust.Length);
				Vector2 dustPos = projectile.Center + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / 60 * i)) * ((auraRadius + auraRadius) / 2);
				int dustIndex = Dust.NewDust(dustPos, 1, 1, dustType);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity = Vector2.Zero;
			}
			base.PostAI();
		}

		public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            hitbox = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, auraRadius, auraRadius);
		}
	}
}
