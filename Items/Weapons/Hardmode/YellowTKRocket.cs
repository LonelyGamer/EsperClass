using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.Hardmode
{
    public class YellowTKRocket : RedTKRocket
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yellow TK Rocket");
        }
        
        public override void SetDefaults()
        {
			base.SetDefaults();
			item.shoot = mod.ProjectileType("YellowTKRocket");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.YellowRocket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
