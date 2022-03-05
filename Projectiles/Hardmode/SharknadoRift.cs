using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EsperClass.Projectiles.Hardmode
{
    public class SharknadoRift : BaseRiftProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projType = mod.ProjectileType("SharknadoRiftProj");
			fireDelay = 60;
			fireVel = 24f;
		}

		public override void Fire(Vector2 vector2, int target = -1)
		{
			Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 19);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector2.X, vector2.Y, projType, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
		}
	}
}
