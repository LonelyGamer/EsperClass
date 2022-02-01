using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Tools
{
	public class GravityDrill : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 25;
			item.shoot = mod.ProjectileType("GravityDrill");
			item.useTime = 2;
			item.shootSpeed = 32f;
			item.knockBack = 0f;
			item.width = 52;
			item.height = 14;
			item.damage = 50;
			item.pick = 225;
			item.UseSound = SoundID.Item23;
			item.rare = 10;
			item.value = Item.sellPrice(0, 7, 0, 0);
			item.noMelee = true;
			item.noUseGraphic = true;
			item.melee = true;
			item.channel = true;
			item.autoReuse = true;
			item.tileBoost += 2;
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
