using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.PreHardmode
{
	public class FireVialNecklace : ECTagItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 28;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = 1;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Enchants telekinetic attacks with pyrokinesis, enabling a chance to cause 'On Fire!' on hit");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).fireVial = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 12);
			recipe.AddIngredient(ItemID.Gel, 20);
			recipe.anyIronBar = true;
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
