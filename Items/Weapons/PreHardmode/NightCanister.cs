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
	public class NightCanister : ECItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Midnight Canister");
			Tooltip.SetDefault("Pours down damaging liquid");
		}

		public override void SetDefaults()
		{
      item.channel = true;
			item.maxStack = 1;
			item.damage = 30;
			item.width = 16;
			item.height = 28;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 0;
			item.value = Item.sellPrice(0, 1, 8, 0);
			item.rare = 3;
      item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("NightCanister");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(null, "DemoniteCanister");
			recipe.AddIngredient(null, "JungleCanister");
			recipe.AddIngredient(null, "DungeonCanister");
			recipe.AddIngredient(null, "HellstoneCanister");
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CrimtaneCanister");
			recipe.AddIngredient(null, "JungleCanister");
			recipe.AddIngredient(null, "DungeonCanister");
			recipe.AddIngredient(null, "HellstoneCanister");
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
