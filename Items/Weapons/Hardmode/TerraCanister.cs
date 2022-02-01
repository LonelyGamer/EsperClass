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
    public class TerraCanister : ECItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature’s Dew");
            Tooltip.SetDefault("Rapidly pours down a piercing liquid\nCauses shorter target immune frames on hit\nAlso acts like a rift weapon\nDoes more damage (up to a limit) the further it falls");
        }

        public override void SetDefaults()
        {
			item.channel = true;
			item.maxStack = 1;
			item.damage = 72;
			item.width = 22;
			item.height = 58;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 0;
			item.value = Item.sellPrice(0, 20, 0, 0);
			item.rare = 8;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 24f;
			item.shoot = mod.ProjectileType("TerraCanister");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TrueNightCanister");
			recipe.AddIngredient(null, "TrueHallowedCanister");
			recipe.AddIngredient(ItemID.ShroomiteBar, 12);
			recipe.AddIngredient(ItemID.SpectreBar, 12);
			recipe.AddIngredient(ItemID.SpookyWood, 150);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
