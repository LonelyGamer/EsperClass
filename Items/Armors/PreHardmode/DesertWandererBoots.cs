using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Armors.PreHardmode
{
	[AutoloadEquip(EquipType.Legs)]
	public class DesertWandererBoots : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("10% increased telekinesis critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 20, 30);
			item.rare = 1;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkCrit += 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AntlionMandible, 3);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
