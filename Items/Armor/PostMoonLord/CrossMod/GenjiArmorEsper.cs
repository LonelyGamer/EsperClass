using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Armor.PostMoonLord.CrossMod
{
	[AutoloadEquip(EquipType.Body)]
	public class GenjiArmorEsper : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink Genji Armor");
			Tooltip.SetDefault("25% increased telekinetic crit chance\n" + "Max Life increased by 150");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000000;
			item.rare = 11;
			item.defense = 25;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine line2 in list)
			{
				if (line2.mod == "Terraria" && line2.Name == "ItemName")
				{
					line2.overrideColor = new Color(0, 255, 0);
				}
			}
			base.ModifyTooltips(list);
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkCrit += 25;
			player.statLifeMax2 += 150;
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("JoostMod");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(otherMod, "GenjiToken", 1);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
