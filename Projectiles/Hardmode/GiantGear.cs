using Microsoft.Xna.Framework;

namespace EsperClass.Projectiles.Hardmode
{
    public class GiantGear : BaseSawbladeProj
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.width = 26;
			projectile.height = 26;
		}

        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            hitbox = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, 64, 64);
		}

		/*public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 26;
			height = 26;
			return true;
		}*/
	}
}
