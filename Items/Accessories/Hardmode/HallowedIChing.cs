using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.Hardmode
{
	public class HallowedIChing : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed I-Ching");
			Tooltip.SetDefault("Increases psychosis recovery by 60%");
		}

		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 14;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = 5;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).accPsychosisRec3 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
