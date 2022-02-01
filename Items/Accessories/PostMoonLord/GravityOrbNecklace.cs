using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.PostMoonLord
{
	[AutoloadEquip(EquipType.Neck)]
	public class GravityOrbNecklace : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("25% chance to TK dodge attacks");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 26;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.rare = 10;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).accTkDodge5 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 3);
			recipe.AddIngredient(null, "GravityFragment", 6);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
