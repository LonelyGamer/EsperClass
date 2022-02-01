using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.Hardmode
{
	public class OrnamentsOrbit : ECItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Orbits eight ornament projectiles around the orb");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 90;
			item.width = 24;
			item.height = 32;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 9, 0, 0);
			item.rare = 8;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 17f;
			item.shoot = mod.ProjectileType("OrnamentsOrbit");
		}
	}
}
