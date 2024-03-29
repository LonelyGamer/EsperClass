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
	public class TrueNightSawblade : ECItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Night's Shred");
            Tooltip.SetDefault("Causes shorter target immune frames on hit");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 72;
			item.width = 34;
			item.height = 34;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 4.5f;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = 8;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 24f;
			item.shoot = mod.ProjectileType("TrueNightSawblade");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NightSawblade");
			recipe.AddIngredient(null, "BrokenHeroPsychicParts");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			Mod otherMod = ModLoader.GetMod("ThoriumMod");
			if (otherMod != null)
			{
				recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "NightSawblade");
				recipe.AddIngredient(otherMod, "BrokenHeroFragment", 2);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
