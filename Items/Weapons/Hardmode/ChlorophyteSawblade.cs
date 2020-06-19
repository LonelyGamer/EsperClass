using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.Hardmode
{
	public class ChlorophyteSawblade : ECItem
	{
		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 60;
			item.width = 22;
			item.height = 22;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 27, 60, 0);
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 24f;
			item.shoot = mod.ProjectileType("ChlorophyteSawblade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
