using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.Hardmode
{
	[AutoloadEquip(EquipType.Head)]
	public class WyvernFeatherCowl : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("18% increased throwing and telekinetic damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = 5;
			item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.18f;
			ECPlayer.ModPlayer(player).tkDamage += 0.18f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("WyvernScaleVest") && legs.type == mod.ItemType("WyvernScaleGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "50% increased wings time";
			player.wingTimeMax = (int)(player.wingTimeMax * 1.5f);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 10);
			recipe.AddIngredient(null, "WyvernScale", 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumBar, 10);
			recipe.AddIngredient(null, "WyvernScale", 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
