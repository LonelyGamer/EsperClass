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
	public class HellbatJar : ECItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Spawns hellbats that will chase your enemies\nRequires shaking up and down to function");
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
			item.knockBack = 3f;
			item.value = Item.sellPrice(0, 2, 70, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("HellbatJar");
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("imkSushisMod");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(otherMod, "UnderworldHellSkeletronToken", 20);
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
