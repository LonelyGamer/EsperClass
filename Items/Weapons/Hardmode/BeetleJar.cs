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
	public class BeetleJar : ECItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Spawns beetles that will chase your enemies\nRequires shaking up and down to function\nWill last for 8 seconds before needing more shaking");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 100;
			item.width = 22;
			item.height = 32;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 7, 0, 0);
			item.rare = 8;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("BeetleJar");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BeetleHusk, 8);
			recipe.AddIngredient(ItemID.LihzahrdBrick, 5);
			recipe.AddTile(TileID.LihzahrdFurnace);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
