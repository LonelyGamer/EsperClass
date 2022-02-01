using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.Hardmode
{
	public class TerraCharmNecklace : ECTagItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = 8;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases psychosis by 12\nIncreases psychosis recovery by 80%\nGives 20% chance to TK dodge attacks");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).accMaxPsychosis4 = true;
			ECPlayer.ModPlayer(player).accPsychosisRec4 = true;
			ECPlayer.ModPlayer(player).accTkDodge4 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ShroomiteOrbNecklace");
			recipe.AddIngredient(null, "SpectreIChing");
			recipe.AddIngredient(null, "BeetleRune");
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
