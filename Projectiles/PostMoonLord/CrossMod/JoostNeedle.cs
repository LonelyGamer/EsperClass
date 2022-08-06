using Terraria;
using Terraria.ID;

namespace EsperClass.Projectiles.PostMoonLord.CrossMod
{
    public class JoostNeedle : ECProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Needle");
		}

		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.localNPCHitCooldown = -1;
			projectile.usesLocalNPCImmunity = true;
			projectile.timeLeft = 120;
			projectile.noEnchantments = true;
			aiType = ProjectileID.WoodenArrowFriendly;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (projectile.localAI[1] < 3)
				damage = (int)(damage * 0.334f);
			base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
		}

		public override void AI()
		{
			projectile.localAI[1]++;
			ExtraAI();
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 2;
			height = 2;
			return true;
		}
	}
}
