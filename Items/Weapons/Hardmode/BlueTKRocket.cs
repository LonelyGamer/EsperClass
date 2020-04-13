using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.Hardmode
{
    public class BlueTKRocket : RedTKRocket
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue TK Rocket");
        }
        
        public override void SetDefaults()
        {
			base.SetDefaults();
			item.shoot = mod.ProjectileType("BlueTKRocket");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BlueRocket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
