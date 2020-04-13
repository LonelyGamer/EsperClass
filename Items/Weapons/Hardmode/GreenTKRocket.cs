using System;
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
            item.autoReuse = true;
            item.channel = true;
            item.maxStack = 999;
            item.consumable = true;
            item.damage = 60;
            item.width = 14;
            item.height = 28;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.knockBack = 5f;
            item.value = Item.sellPrice(0, 0, 0, 20);
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shootSpeed = 10f;
            item.shoot = mod.ProjectileType("GreenTKRocket");
            onlyOne = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenRocket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
