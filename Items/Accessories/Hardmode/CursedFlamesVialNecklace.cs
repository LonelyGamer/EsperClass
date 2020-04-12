using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.Hardmode
{
	public class CursedFlamesVialNecklace : ECTagItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 28;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = 4;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Enchants telekinesis attacks with chlorokinesis, enabling a chance to cause 'Cursed Flames' on hit");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).cursedFlamesVial = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CursedFlame, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
