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
	public class SnowmanBoulder : ECItem
	{
		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 120;
			item.width = 28;
			item.height = 28;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 1;
			item.knockBack = 6f;
			item.value = Item.sellPrice(0, 4, 50, 0);
			item.rare = 5;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("SnowmanBoulder");
			onlyOne = false;
		}

		public override void UpdateInventory(Player player)
		{
			if (item.stack > 1)
				item.stack = 1;
		}
	}
}
