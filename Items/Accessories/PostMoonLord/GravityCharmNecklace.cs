using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.PostMoonLord
{
	public class GravityCharmNecklace : ECTagItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.value = Item.sellPrice(0, 24, 0, 0);
			item.rare = 10;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases psychosis by 15\nIncreases psychosis recovery by 100%\nGives 25% chance to TK dodge attacks");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).accMaxPsychosis5 = true;
			ECPlayer.ModPlayer(player).accPsychosisRec5 = true;
			ECPlayer.ModPlayer(player).accTkDodge5 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GravityOrbNecklace");
			recipe.AddIngredient(null, "GravityIChing");
			recipe.AddIngredient(null, "GravityRune");
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
