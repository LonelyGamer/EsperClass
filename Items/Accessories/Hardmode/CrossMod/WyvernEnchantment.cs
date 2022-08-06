using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Accessories.Hardmode.CrossMod
{
    public class WyvernEnchantment : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("50% increased wings time\n'Made from a creature who crates ghost towns'");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.value = Item.sellPrice(0, 0, 0, 5);
			item.rare = 5;
			item.accessory = true;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine line2 in list)
			{
			  if (line2.mod == "Terraria" && line2.Name == "ItemName")
				line2.overrideColor = new Color(217, 217, 217);
			}
			base.ModifyTooltips(list);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = (int)(player.wingTimeMax * 1.5f);
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("FargowiltasSouls");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "WyvernFeatherCowl");
				recipe.AddIngredient(null, "WyvernScaleVest");
				recipe.AddIngredient(null, "WyvernScaleGreaves");
				recipe.AddIngredient(ItemID.Starfury);
				recipe.AddIngredient(ItemID.LuckyHorseshoe);
				recipe.AddIngredient(ItemID.ShinyRedBalloon);
				recipe.AddTile(TileID.CrystalBall);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
