using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EsperClass.Items.Potions.CrossMod
{
	public class GravityPotion : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases telekinetic damage by 50%"
				+ "\nIncreases telekinetic velocity by 50%"
				+ "\nDouble tap " + Language.GetTextValue(Main.ReversedUpDownArmorSetBonuses ? "Key.UP" : "Key.DOWN") + " to summon a gravity field");
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
			item.buffType = mod.BuffType("TelekineticImmulation");
			item.value = Item.sellPrice(0, 0, 2, 0);
			item.buffTime = 28800;
			item.rare = 1;
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("MorePotions");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.LunarOre);
				recipe.AddIngredient(ItemID.PixieDust, 20);
				recipe.AddIngredient(mod, "GravityFragment", 4);
				recipe.AddTile(TileID.Bottles);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
