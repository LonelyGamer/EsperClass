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
	public class BrightTwirler : ECItem
	{
		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 12;
			item.width = 26;
			item.height = 30;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 2f;
			item.value = Item.sellPrice(0, 0, 30, 0);
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("BrightTwirler");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.UltrabrightTorch, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
