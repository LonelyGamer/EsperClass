﻿using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.Hardmode
{
    public class GreenTKRocket : RedTKRocket
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Green TK Rocket");
        }
        
        public override void SetDefaults()
        {
			base.SetDefaults();
			item.shoot = mod.ProjectileType("GreenTKRocket");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenRocket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
