using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class WaspJarProj : BaseJarProj
	{
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_189";
			}
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(189);
			aiType = ProjectileID.Wasp;
			//projectile.aiStyle = 36;
			//projectile.penetrate = 3;
			projectile.magic = false;
			Main.projFrames[projectile.type] = 4;
			projectile.timeLeft = 300;
			projectile.localNPCHitCooldown = 4;
			projectile.usesLocalNPCImmunity = true;
		}
	}
}
