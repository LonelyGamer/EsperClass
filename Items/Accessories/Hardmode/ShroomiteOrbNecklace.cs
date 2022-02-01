using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.Hardmode
{
	[AutoloadEquip(EquipType.Neck)]
	public class ShroomiteOrbNecklace : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("20% chance to TK dodge attacks");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 26;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = 8;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).accTkDodge4 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShroomiteBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
