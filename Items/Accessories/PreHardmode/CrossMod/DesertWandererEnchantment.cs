using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Accessories.PreHardmode.CrossMod
{
    public class DesertWandererEnchantment : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("25% less life drained while using Esper weapons in Over Psychosis state\nImmunity to 'Mighty Wind'\n'Hello there'");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.value = Item.sellPrice(0, 0, 0, 1);
			item.rare = 1;
			item.accessory = true;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine line2 in list)
			{
			  if (line2.mod == "Terraria" && line2.Name == "ItemName")
				line2.overrideColor = new Color(186, 169, 120);
			}
			base.ModifyTooltips(list);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).desertWandererSetBonus = true;
			player.buffImmune[BuffID.WindPushed] = true;
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("FargowiltasSouls");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "DesertWandererHood");
				recipe.AddIngredient(null, "DesertWandererRobe");
				recipe.AddIngredient(null, "DesertWandererBoots");
				recipe.AddIngredient(ItemID.AntlionClaw); //Mandible Blade
				recipe.AddIngredient(ItemID.AmberStaff);
				recipe.AddIngredient(ItemID.AntlionMandible, 5);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
