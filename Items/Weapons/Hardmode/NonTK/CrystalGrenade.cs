using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.Hardmode.NonTK
{
    public class CrystalGrenade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Grenade");
            Tooltip.SetDefault("Explodes into Crystal Shards");
        }

        public override void SetDefaults()
        {
			item.damage = 60;
			item.width = 10;
			item.height = 16;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.rare = 5;
			item.noMelee = true;
			item.useStyle = 1;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 4f;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("CrystalGrenade");
			item.shootSpeed = 11f;
			item.UseSound = SoundID.Item1;
			item.thrown = true;
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

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "CrystalFlail");
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

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(null, "CrystalFlail");
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
