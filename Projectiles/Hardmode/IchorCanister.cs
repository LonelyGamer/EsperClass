using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Projectiles.Hardmode
{
	public class IchorCanister : LiquidNitrogenCanister
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			projectile.hide = true;
			projectile.noEnchantments = true;
			maxVel = 16f;
			whizze = false;
			rotate = false;
			releaseRate = 12;
			projType = mod.ProjectileType("IchorCanisterProj");
			pourSpeed = 8f;
		}
	}
}
