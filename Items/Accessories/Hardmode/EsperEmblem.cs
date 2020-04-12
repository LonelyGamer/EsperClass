using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.Hardmode
{
	public class EsperEmblem : ECTagItem
	{
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 4;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("15% increased telekinetic damage");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).tkDamage += 0.15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.AvengerEmblem);
			recipe.AddRecipe();

			Mod otherMod = ModLoader.GetMod("imkSushisMod");
			if (otherMod != null)
			{
				//From
				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.WarriorEmblem);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.RangerEmblem);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.SorcererEmblem);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.SummonerEmblem);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				//To
				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.WarriorEmblem);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.RangerEmblem);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.SorcererEmblem);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.SummonerEmblem);
				recipe.AddRecipe();

				Mod expandedSentries = ModLoader.GetMod("ExpandedSentries");
				if (expandedSentries != null)
				{
					recipe = new ModRecipe(mod);
					recipe.AddIngredient(expandedSentries, "DefenderEmblem");
					recipe.AddIngredient(otherMod, "SwapToken");
					recipe.AddTile(TileID.TinkerersWorkbench);
					recipe.SetResult(this);
					recipe.AddRecipe();

					recipe = new ModRecipe(mod);
					recipe.AddIngredient(this);
					recipe.AddIngredient(otherMod, "SwapToken");
					recipe.AddTile(TileID.TinkerersWorkbench);
					recipe.SetResult(expandedSentries, "DefenderEmblem");
					recipe.AddRecipe();
				}
			}
			/*otherMod = ModLoader.GetMod("BossLootPlus");
			if (otherMod != null)
			{
				recipe = new ModRecipe(mod);
				recipe.AddIngredient(otherMod, "LightDarkEssence", 5);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}*/
		}
	}
}
