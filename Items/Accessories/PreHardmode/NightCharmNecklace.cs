using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Accessories.PreHardmode
{
	public class NightCharmNecklace : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.value = Item.sellPrice(0, 6, 0, 0);
			item.rare = 3;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases psychosis by 6\nIncreases psychosis recovery by 40%\nGives 10% chance to TK dodge attacks");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).accMaxPsychosis2 = true;
			ECPlayer.ModPlayer(player).accPsychosisRec2 = true;
			ECPlayer.ModPlayer(player).accTkDodge2 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NightOrbNecklace");
			recipe.AddIngredient(null, "NightIChing");
			recipe.AddIngredient(null, "NightRune");
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
