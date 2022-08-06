using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Accessories.Hardmode.CrossMod
{
    public class LihzahrdSolarEnchantment : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases telekinetic damage when spending psychosis\nCauses an explosion at weapon after enough time and resets the bonus\n'One of the Lihzahrd secrets, yours to use'");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.value = Item.sellPrice(0, 0, 0, 8);
			item.rare = 8;
			item.accessory = true;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine line2 in list)
			{
			  if (line2.mod == "Terraria" && line2.Name == "ItemName")
				line2.overrideColor = new Color(196, 119, 0);
			}
			base.ModifyTooltips(list);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).lihzahrdSetBonus = true;
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("FargowiltasSouls");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "LihzahrdSolarMask");
				recipe.AddIngredient(null, "LihzahrdSolarChestplate");
				recipe.AddIngredient(null, "LihzahrdSolarGreaves");
				recipe.AddIngredient(ItemID.Picksaw);
				recipe.AddIngredient(ItemID.EyeoftheGolem);
				recipe.AddIngredient(ItemID.SunStone);
				recipe.AddTile(TileID.CrystalBall);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
