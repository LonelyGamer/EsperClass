using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.Hardmode
{
	public class HallowedRune : ECTagItem
	{
		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 20;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 5;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases psychosis by 9");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).accMaxPsychosis3 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
