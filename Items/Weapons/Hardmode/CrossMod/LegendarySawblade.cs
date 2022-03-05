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
    public class LegendarySawblade : ECItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Tier 5 Sawblade\nLeaves behind exploding homing projectiles every so often");
        }

        public override void SetDefaults()
        {
			item.channel = true;
			item.maxStack = 1;
			item.damage = 75;
			item.width = 28;
			item.height = 28;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 20, 0, 0);
			item.rare = 9;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 24f;
			item.shoot = mod.ProjectileType("LegendarySawblade");
		}

		public override void AddRecipes()
		{
			Mod LootBags = ModLoader.GetMod("LootBags");
			if (LootBags != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(LootBags, "LegendaryCore");
				recipe.AddIngredient(ItemID.BeetleHusk, 10);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}			
		}
	}
}
