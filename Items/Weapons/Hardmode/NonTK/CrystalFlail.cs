using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Weapons.Hardmode.NonTK
{
	public class CrystalFlail : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 36;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.rare = 5;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 4f;
			item.damage = 50;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("CrystalFlail");
			item.shootSpeed = 15.1f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("imkSushisMod");
			if (otherMod != null)
			{
				//From
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.FlyingKnife);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.DaedalusStormbow);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.CrystalVileShard);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.IlluminantHook);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				//To
				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.FlyingKnife);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.DaedalusStormbow);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.CrystalVileShard);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.IlluminantHook);
				recipe.AddRecipe();
			}
			Mod expandedSentries = ModLoader.GetMod("ExpandedSentries");
			if (expandedSentries != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(expandedSentries, "HallowedMimicTrap");
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(expandedSentries, "HallowedMimicTrap");
				recipe.AddRecipe();
			}
		}
	}
}