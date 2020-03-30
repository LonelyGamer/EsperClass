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
	public class CrimtaneSawblade : ECItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Butcher's Barbs");
			Tooltip.SetDefault("Slower than Corruption counterpart");
		}

		public override void SetDefaults()
		{
      item.channel = true;
			item.maxStack = 1;
			item.damage = 18;
			item.width = 22;
			item.height = 22;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 3f;
			item.value = Item.sellPrice(0, 1, 35, 0);
			item.rare = 1;
      item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("CrimtaneSawblade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
