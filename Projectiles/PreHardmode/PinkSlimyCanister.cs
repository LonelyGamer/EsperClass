using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class PinkSlimyCanister : SlimyCanister
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			projectile.hide = true;
			projectile.noEnchantments = true;
			maxVel = 16f;
			whizze = false;
			rotate = false;
			releaseRate = 15;
			projType = mod.ProjectileType("PinkSlimyCanisterProj");
			pourSpeed = 6f;
		}
	}
}
