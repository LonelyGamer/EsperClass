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
	public class TKMeteor : ECItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("TK Meteor");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 999;
			item.consumable = true;
			item.damage = 60;
			item.width = 26;
			item.height = 26;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 1;
			item.knockBack = 5f;
			item.value = Item.sellPrice(0, 0, 0, 20);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 10f;
			item.shoot = mod.ProjectileType("TKMeteor");
			onlyOne = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}
