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
	public class HellstoneCanister : ECItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lava Canister");
			Tooltip.SetDefault("Pours down lava");
		}

		public override void SetDefaults()
		{
      item.channel = true;
			item.maxStack = 1;
			item.damage = 25;
			item.width = 16;
			item.height = 30;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 0;
			item.value = Item.sellPrice(0, 2, 70, 0);
			item.rare = 3;
      item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("HellstoneCanister");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 20);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
