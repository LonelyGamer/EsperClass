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
    public class TrueHallowedCanister : ECItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Goldropper");
            Tooltip.SetDefault("Pours down a piercing liquid\nDoes more damage (up to a limit) the further it falls\nAlso acts like a rift weapon");
        }

        public override void SetDefaults()
        {
			item.maxStack = 1;
			item.damage = 66;
			item.width = 12;
			item.height = 26;
			item.useTime = 15;
			item.useAnimation = 15;
			item.knockBack = 0;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = 8;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("TrueHallowedCanister");
			base.SetDefaults();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "HallowedCanister");
			recipe.AddIngredient(null, "BrokenHeroPsychicParts");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			Mod otherMod = ModLoader.GetMod("ThoriumMod");
			if (otherMod != null)
			{
				recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "HallowedCanister");
				recipe.AddIngredient(otherMod, "BrokenHeroFragment", 2);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
