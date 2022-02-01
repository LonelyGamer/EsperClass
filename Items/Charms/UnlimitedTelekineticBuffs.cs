using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Charms
{
	public class UnlimitedTelekineticBuffs : ECTagItem
	{
		public override string Texture
		{
			get
			{
				return "EsperClass/Buffs/Willful";
			}
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("You embody mind over matter");
		}

		public override void SetDefaults()
		{
			item.maxStack = 1;
			item.width = 12;
			item.height = 12;
			item.value = 1;
			item.rare = 10;
		}

		public override void UpdateInventory(Player player)
		{
			ECPlayer.ModPlayer(player).willfulPotion = true;
			ECPlayer.ModPlayer(player).focusedPotion = true;
			ECPlayer.ModPlayer(player).alertPotion = true;
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("Luiafk");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "UnlimitedWillPotion");
				recipe.AddIngredient(null, "UnlimitedFocusPotion");
				recipe.AddIngredient(null, "UnlimitedAlertnessPotion");
				recipe.AddTile(TileID.Bottles);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
