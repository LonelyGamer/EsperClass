using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Potions
{
	public class AlertnessPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases telekinetic velocity by 30%");
		}

		public override void SetDefaults()
		{
			item.UseSound = SoundID.Item3;
			item.useStyle = 2;
			item.useTurn = true;
			item.useAnimation = 17;
			item.useTime = 17;
			item.maxStack = 30;
			item.consumable = true;
			item.width = 14;
			item.height = 24;
			item.buffType = mod.BuffType("Alert");
			item.buffTime = 18000;
			item.value = 1000;
			item.rare = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Lens);
			recipe.AddIngredient(ItemID.Deathweed);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
