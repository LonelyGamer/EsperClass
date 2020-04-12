using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Potions
{
	public class FocusPotion : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases telekinetic critical by 12%");
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
			item.buffType = mod.BuffType("Focused");
			item.buffTime = 14400;
			item.value = 1000;
			item.rare = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Lens);
			recipe.AddIngredient(ItemID.Fireblossom);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
