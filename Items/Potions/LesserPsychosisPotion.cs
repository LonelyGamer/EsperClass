using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Potions
{
	public class LesserPsychosisPotion : PsychosisPotion
	{
		public override int restoreAmount => 10;

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Restores 10 psychosis\nTake damage equal to amount of psychosis restored");
		}

		public override void SetDefaults()
		{
			item.UseSound = SoundID.Item3;
			item.useStyle = 2;
			item.useTurn = true;
			item.useAnimation = 17;
			item.useTime = 17;
			item.maxStack = 50;
			item.consumable = true;
			item.width = 14;
			item.height = 24;
			item.value = Item.buyPrice(0, 0, 1, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bottle, 2);
			recipe.AddIngredient(ItemID.Daybloom);
			recipe.AddIngredient(ItemID.Gel, 2);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}
	}
}
