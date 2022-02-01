using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.PreHardmode
{
	[AutoloadEquip(EquipType.Head)]
	public class TaurusHelmet : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("20% increased telekinetic damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = 3;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkDamage += 0.2f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("TaurusChestplate") && legs.type == mod.ItemType("TaurusGreaves");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			int line = tooltips.FindLastIndex(x => x.mod == "Terraria" && x.Name == "Tooltip0");
			if (line >= 0)
			{
				TooltipLine newtip = new TooltipLine(mod, "Warning", "Only works if no other vanilla dash accessory or Solar Armor set bonus is active");
				newtip.overrideColor = new Color(255, 0, 0);
				tooltips.Insert(line + 1, newtip);
			}
			base.ModifyTooltips(tooltips);
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Enables Psy Dashing.\nDouble tap a cardinal direction to dash that way.\nGain 20 immunity frames during the dash.\nCosts 5 psychosis to use\nTake 20 damage if used during Psyched Out state";
			ECPlayer.ModPlayer(player).taurusSetBonus = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BlackLens);
			recipe.AddIngredient(ItemID.Lens, 2);
			recipe.AddIngredient(ItemID.Bone, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
