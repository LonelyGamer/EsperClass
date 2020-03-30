using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Accessories.PreHardmode
{
	[AutoloadEquip(EquipType.Neck)]
	public class NightOrbNecklace : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 26;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 3;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("10% chance to TK dodge attacks");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).accTkDodge2 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddIngredient(ItemID.Stinger, 2);
			recipe.AddIngredient(ItemID.Bone, 5);
			recipe.AddIngredient(ItemID.HellstoneBar, 3);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TissueSample, 5);
			recipe.AddIngredient(ItemID.Stinger, 2);
			recipe.AddIngredient(ItemID.Bone, 5);
			recipe.AddIngredient(ItemID.HellstoneBar, 3);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
