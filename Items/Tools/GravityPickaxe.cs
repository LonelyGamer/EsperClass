using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Tools
{
	public class GravityPickaxe : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.useAnimation = 12;
			item.useTime = 6;
			item.knockBack = 5.5f;
			item.useTurn = true;
			item.autoReuse = true;
			item.width = 34;
			item.height = 34;
			item.damage = 80;
			item.pick = 225;
			item.UseSound = SoundID.Item1;
			item.rare = 10;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.melee = true;
			item.tileBoost += 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(null, "GravityFragment", 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
