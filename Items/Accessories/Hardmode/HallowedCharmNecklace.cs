using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.Hardmode
{
	public class HallowedCharmNecklace : ECTagItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.value = Item.sellPrice(0, 6, 0, 0);
			item.rare = 5;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases psychosis by 9\nIncreases psychosis recovery by 60%\nGives 15% chance to TK dodge attacks");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).accMaxPsychosis3 = true;
			ECPlayer.ModPlayer(player).accPsychosisRec3 = true;
			ECPlayer.ModPlayer(player).accTkDodge3 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "HallowedOrbNecklace");
			recipe.AddIngredient(null, "HallowedIChing");
			recipe.AddIngredient(null, "HallowedRune");
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
