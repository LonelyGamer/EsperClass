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
	public class SlimyCanister : ECItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Pours down damaging slimy liquid\nDoes more damage (up to a limit) the further it falls");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 9;
			item.width = 16;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 0;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = 1;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("SlimyCanister");
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("imkSushisMod");
			Mod expandedSentries = ModLoader.GetMod("ExpandedSentries");
			if (otherMod != null && expandedSentries != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(expandedSentries, "SlimeSpiker");
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(expandedSentries, "SlimeSpiker");
				recipe.AddRecipe();
			}
		}
	}
}
