using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.PreHardmode
{
	[AutoloadEquip(EquipType.Neck)]
	public class EnchantedOrbNecklace : ECTagItem
	{
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 26;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 1;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Gives 5% chance to TK dodge attacks");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).accTkDodge1 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("EsperClass:Tier4Bar", 5);
			recipe.AddIngredient(ItemID.Obsidian, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
