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
	public class PixieJar : ECItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Spawns one of three coloured pixies that will hunt down enemies\nRequires shaking up and down to function");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 44;
			item.width = 16;
			item.height = 28;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 1f;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("PixieJar");
		}

		public override void AddRecipes()
		{
			/*ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PixieDust, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();*/
			Mod otherMod = ModLoader.GetMod("imkSushisMod");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(otherMod, "LootHardmodeToken", 25);
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
