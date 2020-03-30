using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Accessories.PreHardmode
{
	public class NightIChing : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Night I-Ching");
			Tooltip.SetDefault("Increases psychosis recovery by 40%");
		}

		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 14;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 3;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).accPsychosisRec2 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddIngredient(ItemID.Stinger, 2);
			recipe.AddIngredient(ItemID.Bone, 5);
			recipe.AddIngredient(ItemID.HellstoneBar, 3);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TissueSample, 5);
			recipe.AddIngredient(ItemID.Stinger, 2);
			recipe.AddIngredient(ItemID.Bone, 5);
			recipe.AddIngredient(ItemID.HellstoneBar, 3);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
