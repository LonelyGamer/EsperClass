using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Placeables
{
	public class GravityChandelier : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 99;
			item.consumable = true;
			item.createTile = TileType<Tiles.GravityChandelier>();
			item.width = 26;
			item.height = 26;
			item.value = Item.sellPrice(0, 0, 6, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Torch);
			recipe.AddIngredient(null, "GravityBrick", 4);
			recipe.AddIngredient(ItemID.Torch, 4);
			recipe.AddIngredient(ItemID.Chain);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}