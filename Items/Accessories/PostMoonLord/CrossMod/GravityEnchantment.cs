using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EsperClass.Items.Accessories.PostMoonLord.CrossMod
{
    public class GravityEnchantment : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Double tap " + Language.GetTextValue(Main.ReversedUpDownArmorSetBonuses ? "Key.UP" : "Key.DOWN") + " to summon a gravity to suck in enemies\nIncreases flight time while inside\n'Up, down, left, right it's all the same to you'");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.value = Item.sellPrice(0, 0, 0, 10);
			item.rare = 10;
			item.accessory = true;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine line2 in list)
			{
			  if (line2.mod == "Terraria" && line2.Name == "ItemName")
				line2.overrideColor = new Color(255, 206, 49);
			}
			base.ModifyTooltips(list);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).gravitySetBonus = true;
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("FargowiltasSouls");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "GravityHelmet");
				recipe.AddIngredient(null, "GravityRobe");
				recipe.AddIngredient(null, "GravityLeggings");
				recipe.AddIngredient(null, "AccretionDisc");
				recipe.AddIngredient(null, "BlackHoleBomb");
				recipe.AddIngredient(null, "EldritchEyeJar");
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
