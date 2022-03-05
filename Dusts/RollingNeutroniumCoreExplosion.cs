using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EsperClass.Dusts
{
	public class RollingNeutroniumCoreExplosion : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.frame = new Rectangle(0, 0, 56, 80);
			dust.alpha = 0;
			dust.scale = 2;
		}

		public override bool Update(Dust dust)
		{
			//dust.scale += 0.1f;
			dust.alpha += 4;
			//if (dust.scale >= 3f)
			if (dust.alpha >= 127)
			{
				dust.active = false;
			}
			return false;
		}
	}
}