﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace EsperClass.Items.Placeables
{
	public class GravityFragmentBlock : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("GravityFragmentBlock");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GravityFragment");
			recipe.AddIngredient(ItemID.StoneBlock, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}
