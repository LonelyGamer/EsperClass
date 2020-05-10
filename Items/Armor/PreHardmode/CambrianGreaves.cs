using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.PreHardmode
{
	[AutoloadEquip(EquipType.Legs)]
	public class CambrianGreaves : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("12% increased telekinetic critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 20, 30);
			item.rare = 2;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkCrit += 12;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FossilOre, 8);
			recipe.AddIngredient(ItemID.Coral, 6);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
