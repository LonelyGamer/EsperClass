using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.PreHardmode
{
	public class EnchantedRune : ECTagItem
	{
		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 20;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 1;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases psychosis by 3");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).accMaxPsychosis1 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("EsperClass:Tier4Bar", 5);
			recipe.AddIngredient(ItemID.Obsidian, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
