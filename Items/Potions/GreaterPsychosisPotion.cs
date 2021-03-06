using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Potions
{
	public class GreaterPsychosisPotion : PsychosisPotion
	{
		public override int restoreAmount => 40;

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Restores 40 psychosis\nTake damage equal to amount of psychosis restored");
		}

		public override void SetDefaults()
		{
			item.UseSound = SoundID.Item3;
			item.useStyle = 2;
			item.useTurn = true;
			item.useAnimation = 17;
			item.useTime = 17;
			item.maxStack = 75;
			item.consumable = true;
			item.width = 14;
			item.height = 24;
			item.value = Item.buyPrice(0, 0, 5, 0);
			item.rare = 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bottle);
			recipe.AddIngredient(ItemID.FallenStar);
			recipe.AddIngredient(ItemID.CrystalShard);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
