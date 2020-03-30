using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.PreHardmode
{
	public class NightSawblade : ECItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Night's Shred");
		}

		public override void SetDefaults()
		{
      item.channel = true;
			item.maxStack = 1;
			item.damage = 30;
			item.width = 22;
			item.height = 22;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 4.5f;
			item.value = Item.sellPrice(0, 1, 8, 0);
			item.rare = 3;
      item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("NightSawblade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(null, "DemoniteSawblade");
			recipe.AddIngredient(null, "JungleSawblade");
			recipe.AddIngredient(null, "DungeonSawblade");
			recipe.AddIngredient(null, "HellstoneSawblade");
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CrimtaneSawblade");
			recipe.AddIngredient(null, "JungleSawblade");
			recipe.AddIngredient(null, "DungeonSawblade");
			recipe.AddIngredient(null, "HellstoneSawblade");
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
