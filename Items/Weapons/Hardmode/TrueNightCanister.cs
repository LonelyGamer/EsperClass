using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.Hardmode
{
    public class TrueNightCanister : ECItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Midnight Canister");
            Tooltip.SetDefault("Rapidly pours down a piercing liquid\nCauses shorter target immune frames on hit");
        }

        public override void SetDefaults()
        {
			item.channel = true;
			item.maxStack = 1;
			item.damage = 72;
			item.width = 22;
			item.height = 38;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 0;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 24f;
			item.shoot = mod.ProjectileType("TrueNightCanister");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NightCanister");
			recipe.AddIngredient(null, "BrokenHeroPsychicParts");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			Mod otherMod = ModLoader.GetMod("ThoriumMod");
			if (otherMod != null)
			{
				recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "NightCanister");
				recipe.AddIngredient(otherMod, "BrokenHeroFragment", 2);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
