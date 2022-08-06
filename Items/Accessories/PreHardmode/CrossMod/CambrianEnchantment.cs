using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Accessories.PreHardmode.CrossMod
{
    public class CambrianEnchantment : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Free movement in liquid\nEsper projectiles no longer slower in liquid\n'She sells seashells by the seashore'");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.value = Item.sellPrice(0, 0, 0, 2);
			item.rare = 2;
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
            player.ignoreWater = true;
            player.accFlipper = true;
			ECPlayer.ModPlayer(player).cambrianSetBonus = true;
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("FargowiltasSouls");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "CambrianHelmet");
				recipe.AddIngredient(null, "CambrianChestplate");
				recipe.AddIngredient(null, "CambrianGreaves");
				recipe.AddIngredient(ItemID.Trident);
				recipe.AddIngredient(ItemID.Flipper);
				recipe.AddIngredient(ItemID.BreathingReed);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
