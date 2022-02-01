using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Charms
{
	public class UnlimitedWillPotion : ECTagItem
	{
		public override string Texture
		{
			get
			{
				return "EsperClass/Items/Potions/WillPotion";
			}
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Never will your will falter");
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
			ECPlayer.ModPlayer(player).willfulPotion = true;
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("Luiafk");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "WillPotion", 30);
				recipe.AddTile(TileID.Bottles);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
