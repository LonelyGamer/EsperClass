using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.Hardmode
{
    public class RedTKRocket : ECItem
    {
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_167";
			}
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Psy Rocket");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 150;
			item.width = 14;
			item.height = 28;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 1;
			item.knockBack = 5f;
			item.value = Item.sellPrice(0, 0, 60, 0);
			item.rare = 4;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("RedTKRocket");
			onlyOne = false;
		}

		public override void UpdateInventory(Player player)
		{
			if (item.stack > 1)
				item.stack = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RedRocket, 20);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
