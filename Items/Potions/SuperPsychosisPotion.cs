using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Potions
{
	public class SuperPsychosisPotion : PsychosisPotion
	{
		public override int restoreAmount => -1;

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Restores all psychosis\nTake damage equal to amount of psychosis restored");
		}

		public override void SetDefaults()
		{
			item.UseSound = SoundID.Item3;
			item.useStyle = 2;
			item.useTurn = true;
			item.useAnimation = 17;
			item.useTime = 17;
			item.maxStack = 99;
			item.consumable = true;
			item.width = 14;
			item.height = 24;
			item.value = Item.buyPrice(0, 0, 15, 0);
			item.rare = 7;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GreaterPsychosisPotion", 3);
			recipe.AddIngredient(ItemID.Ectoplasm);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
		}
	}
}
