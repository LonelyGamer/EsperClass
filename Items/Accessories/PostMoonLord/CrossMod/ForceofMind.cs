using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Accessories.PostMoonLord.CrossMod
{
    public class ForceofMind : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Force of Mind");
			Tooltip.SetDefault("Combined set bonus effects of all Esper Class armors\n'Blessings of the mind upon the wearer'");
		}

		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 46;
			item.value = Item.sellPrice(0, 60, 0, 0);
			item.rare = 11;
			item.accessory = true;
		}

		/*public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine line2 in list)
			{
			  if (line2.mod == "Terraria" && line2.Name == "ItemName")
				line2.overrideColor = new Color(255, 206, 49);
			}
			base.ModifyTooltips(list);
		}*/

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).desertWandererSetBonus = true;
			player.buffImmune[BuffID.WindPushed] = true;
            player.ignoreWater = true;
            player.accFlipper = true;
			ECPlayer.ModPlayer(player).cambrianSetBonus = true;
			ECPlayer.ModPlayer(player).taurusSetBonus = true;
			player.wingTimeMax = (int)(player.wingTimeMax * 1.5f);
			ECPlayer.ModPlayer(player).lihzahrdSetBonus = true;
			ECPlayer.ModPlayer(player).gravitySetBonus = true;
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("Fargowiltas");
			Mod otherMod2 = ModLoader.GetMod("FargowiltasSouls");
			if (otherMod != null && otherMod2 != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "DesertWandererEnchantment");
				recipe.AddIngredient(null, "CambrianEnchantment");
				recipe.AddIngredient(null, "TaurusEnchantment");
				recipe.AddIngredient(null, "WyvernEnchantment");
				recipe.AddIngredient(null, "LihzahrdSolarEnchantment");
				recipe.AddIngredient(null, "GravityEnchantment");
				recipe.AddTile(otherMod, "CrucibleCosmosSheet");
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
