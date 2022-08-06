using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Armor.PostMoonLord.CrossMod
{
	[AutoloadEquip(EquipType.Head)]
	public class GenjiHelmEsper : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink Genji Helm");
			Tooltip.SetDefault("60% increased telekinetic damage\n" + "15 increased psychosis");
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

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			Mod otherMod = ModLoader.GetMod("JoostMod");
			if (otherMod != null)
			{
				return body.type == mod.ItemType("GenjiArmorEsper") && legs.type == otherMod.ItemType("GenjiLeggings");
			}
			else
				return false;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases telekinetic velocity by 100%";
			ECPlayer.ModPlayer(player).tkVel += 1f;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
			player.armorEffectDrawOutlines = true;
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkDamage += 0.6f;
			ECPlayer.ModPlayer(player).maxPsychosis2 += 15;
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
