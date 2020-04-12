using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.PreHardmode
{
	public class EnchantedCharmNecklace : ECTagItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.rare = 1;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases psychosis by 3\nIncreases psychosis recovery by 20%\nGives 5% chance to TK dodge attacks");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).accMaxPsychosis1 = true;
			ECPlayer.ModPlayer(player).accPsychosisRec1 = true;
			ECPlayer.ModPlayer(player).accTkDodge1 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EnchantedOrbNecklace");
			recipe.AddIngredient(null, "EnchantedIChing");
			recipe.AddIngredient(null, "EnchantedRune");
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
