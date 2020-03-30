using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.PreHardmode.CrossMod
{
	public class ApprenticeSawblade : ECItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Tier 2 Sawblade");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 30;
			item.width = 22;
			item.height = 22;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 3f;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("ApprenticeSawblade");
		}

		public override void AddRecipes()
		{
			Mod LootBags = ModLoader.GetMod("LootBags");
			if (LootBags != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(LootBags, "ApprenticeCore", 1);
				recipe.AddIngredient(ItemID.HellstoneBar, 10);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this, 1);
				recipe.AddRecipe();
			}
		}
	}
}
