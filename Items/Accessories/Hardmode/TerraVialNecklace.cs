using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.Hardmode
{
	public class TerraVialNecklace : ECTagItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 38;
			item.value = Item.sellPrice(0, 20, 0, 0);
			item.rare = 8;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Enchants telekinetic attacks with a lot of kinesis, enabling a chance to cause many debuffs on hit");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).fireVial = true;
			ECPlayer.ModPlayer(player).frostburnVial = true;
			ECPlayer.ModPlayer(player).poisonVial = true;
			ECPlayer.ModPlayer(player).midasVial = true;
			ECPlayer.ModPlayer(player).cursedFlamesVial = true;
			ECPlayer.ModPlayer(player).ichorVial = true;
			ECPlayer.ModPlayer(player).shadowflameVial = true;
			ECPlayer.ModPlayer(player).venomVial = true;
			ECPlayer.ModPlayer(player).terraVial = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FireVialNecklace");
			recipe.AddIngredient(null, "FrostVialNecklace");
			recipe.AddIngredient(null, "PoisonVialNecklace");
			recipe.AddIngredient(null, "CursedFlamesVialNecklace");
			recipe.AddIngredient(null, "IchorVialNecklace");
			recipe.AddIngredient(null, "MidasVialNecklace");
			recipe.AddIngredient(null, "ShadowflameVialNecklace");
			recipe.AddIngredient(null, "VenomVialNecklace");
			recipe.AddIngredient(ItemID.BeetleHusk);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
