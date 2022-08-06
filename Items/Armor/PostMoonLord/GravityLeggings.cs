using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.PostMoonLord
{
	[AutoloadEquip(EquipType.Legs)]
	public class GravityLeggings : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("20% increased movement speed\n12% increased telekinetic damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 10, 50, 0);
			item.rare = 10;
			item.defense = 13;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.2f;
			ECPlayer.ModPlayer(player).tkDamage += 0.12f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddIngredient(null, "GravityFragment", 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
