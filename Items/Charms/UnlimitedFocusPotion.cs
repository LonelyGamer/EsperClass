using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Charms
{
	public class UnlimitedFocusPotion : ECTagItem
	{
		public override string Texture
		{
			get
			{
				return "EsperClass/Items/Potions/FocusPotion";
			}
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Your focus stays on point");
		}

		public override void SetDefaults()
		{
			item.maxStack = 1;
			item.width = 14;
			item.height = 24;
			item.value = 1;
			item.rare = 10;
		}

		public override void UpdateInventory(Player player)
		{
			ECPlayer.ModPlayer(player).focusedPotion = true;
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("Luiafk");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "FocusPotion", 30);
				recipe.AddTile(TileID.Bottles);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
