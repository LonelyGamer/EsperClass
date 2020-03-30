using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Armors.PreHardmode
{
	[AutoloadEquip(EquipType.Legs)]
	public class TaurusGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("15% increased telekinesis critical strike chance");
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
			ECPlayer.ModPlayer(player).tkCrit += 15;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Lens, 3);
			recipe.AddIngredient(ItemID.Bone, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
