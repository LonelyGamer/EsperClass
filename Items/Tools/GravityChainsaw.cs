using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Tools
{
	public class GravityChainsaw : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 25;
			item.shoot = mod.ProjectileType("GravityChainsaw");
			item.useTime = 4;
			item.shootSpeed = 28f;
			item.knockBack = 4f;
			item.width = 52;
			item.height = 14;
			item.damage = 80;
			item.axe = 27;
			item.UseSound = SoundID.Item23;
			item.rare = 10;
			item.value = Item.sellPrice(0, 6, 0, 0);
			item.noMelee = true;
			item.noUseGraphic = true;
			item.melee = true;
			item.channel = true;
			item.autoReuse = true;
			item.tileBoost += 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GravityFragment", 12);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
