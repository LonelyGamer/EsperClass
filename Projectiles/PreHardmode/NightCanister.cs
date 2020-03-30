using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.PreHardmode
{
	public class NightCanister : SlimyCanister
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			projectile.hide = true;
			projectile.noEnchantments = true;
			maxVel = 16f;
			whizze = false;
			rotate = false;
			releaseRate = 12;
			projType = mod.ProjectileType("NightCanisterProj");
			pourSpeed = 8f;
		}
	}
}
