using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.PreHardmode
{
	[AutoloadEquip(EquipType.Head)]
	public class DesertWandererHood : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			//DisplayName.SetDefault("Desert Wanderer Cowl");
			Tooltip.SetDefault("15% increased telekinetic damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 20, 20);
			item.rare = 1;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkDamage += 0.15f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("DesertWandererRobe") && legs.type == mod.ItemType("DesertWandererBoots");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "25% less life drained while using Esper weapons in Over Psychosis state\nImmunity to 'Mighty Wind'";
			ECPlayer.ModPlayer(player).desertWandererSetBonus = true;
			player.buffImmune[BuffID.WindPushed] = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AntlionMandible, 2);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
