using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.Hardmode
{
	[AutoloadEquip(EquipType.Legs)]
	public class WyvernScaleGreaves : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("12% increased throwing and telekinetic critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.rare = 5;
			item.defense = 12;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownCrit += 12;
			ECPlayer.ModPlayer(player).tkCrit += 12;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 16);
			recipe.AddIngredient(null, "WyvernScale", 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumBar, 16);
			recipe.AddIngredient(null, "WyvernScale", 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
