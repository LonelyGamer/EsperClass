using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Tools
{
	public class GravityHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Not to be confused with a Type-2 Energy Hammer'");
		}

		public override void SetDefaults()
		{
			item.useTurn = true;
			item.autoReuse = true;
			item.useStyle = 1;
			item.useAnimation = 28;
			item.useTime = 7;
			item.knockBack = 7f;
			item.width = 50;
			item.height = 46;
			item.damage = 110;
			item.hammer = 100;
			item.UseSound = SoundID.Item1;
			item.rare = 10;
			item.value = Item.sellPrice(0, 2, 50, 0);
			item.melee = true;
			item.tileBoost += 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 5);
			recipe.AddIngredient(null, "GravityFragment", 6);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
