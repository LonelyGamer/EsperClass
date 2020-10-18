using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.Hardmode.CrossMod
{
    public class EpicSawblade : ECItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Tier 4 Sawblade\nProjectile explodes");
        }

        public override void SetDefaults()
        {
			item.channel = true;
			item.maxStack = 1;
			item.damage = 60;
			item.width = 34;
			item.height = 34;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 24f;
			item.shoot = mod.ProjectileType("EpicSawblade");
		}

		public override void AddRecipes()
		{
			Mod LootBags = ModLoader.GetMod("LootBags");
			if (LootBags != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(LootBags, "EpicCore");
				recipe.AddIngredient(ItemID.HallowedBar, 10);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}			
		}
	}
}
