using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Accessories.PreHardmode.CrossMod
{
    public class TaurusEnchantment : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Enables Psi Dashing.\nDouble tap a cardinal direction to dash that way.\nGain 20 immunity frames during the dash.\nCosts 5 psychosis to use\nTake 20 damage if used during Psyched Out state\n'Give them the bull!'");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.value = Item.sellPrice(0, 0, 0, 3);
			item.rare = 3;
			item.accessory = true;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine line2 in list)
			{
			  if (line2.mod == "Terraria" && line2.Name == "ItemName")
				line2.overrideColor = new Color(238, 140, 86);
			}
			base.ModifyTooltips(list);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).taurusSetBonus = true;
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("FargowiltasSouls");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "TaurusHelmet");
				recipe.AddIngredient(null, "TaurusChestplate");
				recipe.AddIngredient(null, "TaurusGreaves");
				recipe.AddIngredient(ItemID.AquaScepter);
				recipe.AddIngredient(ItemID.BlueMoon);
				recipe.AddIngredient(ItemID.MagicMissile);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
