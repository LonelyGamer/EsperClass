using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
    public class RollingNeutroniumCoreExplosionFx : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 112;
			projectile.height = 160;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.noEnchantments = true;
			projectile.hide = true;
		}

		public override void AI()
		{
			projectile.alpha += 4;
			if (projectile.alpha >= 127)
				projectile.Kill();
		}

		public override bool? CanCutTiles()
		{
			return false;
		}

		public override bool? CanHitNPC(NPC npc)
		{
			return false;
		}

		public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
		{
			drawCacheProjsBehindNPCs.Add(index);
		}
	}
}
