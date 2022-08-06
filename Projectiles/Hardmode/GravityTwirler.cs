using System.Collections.Generic;
using EsperClass.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Projectiles.Hardmode
{
    public class GravityTwirler : BaseTwirlerProj
	{
		int proj, proj2;
		public override void SetDefaults()
		{
			base.SetDefaults();
			twirlerDust = DustType<GravitySparkle>();
			dustR = 1f;
			dustG = 0.8f;
			dustB = 0.2f;
			projectile.hide = true;
		}

		public override void PostAI()
		{
			if (projectile.ai[1] == 0)
			{
				projectile.ai[1]++;
				if (projectile.owner == Main.myPlayer)
				{
					Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
					proj = Projectile.NewProjectile(vector.X, vector.Y, 12f, 12f, mod.ProjectileType("GravityTwirlerLaser"), projectile.damage, projectile.knockBack, projectile.owner, 0f, projectile.whoAmI);
					Main.projectile[proj].localAI[1] = 1;
					proj2 = Projectile.NewProjectile(vector.X, vector.Y, 12f, 12f, mod.ProjectileType("GravityTwirlerLaser"), projectile.damage, projectile.knockBack, projectile.owner, 0f, projectile.whoAmI);
					Main.projectile[proj2].localAI[1] = -1;
				}
			}
			if (!held)
            {
				Main.projectile[proj].Kill();
				Main.projectile[proj2].Kill();

			}
			base.PostAI();
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
