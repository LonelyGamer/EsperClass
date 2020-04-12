using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.Hardmode
{
	[AutoloadEquip(EquipType.Neck)]
	public class HallowedOrbNecklace : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("15% chance to TK dodge attacks");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 26;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = 5;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).accTkDodge3 = true;
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
