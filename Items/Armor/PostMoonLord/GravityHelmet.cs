using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.PostMoonLord
{
	[AutoloadEquip(EquipType.Head)]
	public class GravityHelmet : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("15% increased telekinetic critical strike chance\n12% increased telekinetic damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 7, 0, 0);
			item.rare = 10;
			item.defense = 13;
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkCrit += 15;
			ECPlayer.ModPlayer(player).tkDamage += 0.12f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GravityRobe") && legs.type == mod.ItemType("GravityLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Double tap " + Language.GetTextValue(Main.ReversedUpDownArmorSetBonuses ? "Key.UP" : "Key.DOWN") + " to summon a gravity field to suck in enemies\nCosts 15 psychosis, only 1 can be active at a time\nIncreases flight time while inside";
			ECPlayer.ModPlayer(player).gravitySetBonus = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddIngredient(null, "GravityFragment", 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
