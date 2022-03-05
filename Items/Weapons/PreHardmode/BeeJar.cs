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
	public class BeeJar : ECItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Spawns bees that will chase your enemies\nRequires shaking up and down to function\nWill last for 8 seconds before needing more shaking");
		}

		public override void SetDefaults()
		{
			//Bee Apiary
			item.channel = true;
			item.maxStack = 1;
			item.damage = 20;
			item.width = 16;
			item.height = 28;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 1f;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 3;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("BeeJar");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BeeWax, 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
