using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.PostMoonLord.CrossMod
{
    public class GodlySawblade : ECItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Tier 6 Sawblade\nLeaves behind exploding homing projectiles every so often\nExplosions linger");
        }

        public override void SetDefaults()
        {
			item.channel = true;
			item.maxStack = 1;
			item.damage = 90;
			item.width = 32;
			item.height = 32;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 25, 0, 0);
			item.rare = 11;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 24f;
			item.shoot = mod.ProjectileType("GodlySawblade");
		}

		public override void AddRecipes()
		{
			Mod LootBags = ModLoader.GetMod("LootBags");
			if (LootBags != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(LootBags, "GodlyCore");
				recipe.AddIngredient(ItemID.LunarBar, 10);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}			
		}
	}
}
