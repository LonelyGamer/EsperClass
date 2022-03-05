using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Placeables
{
	public class GravityCandelabra : ModItem
	{
		public override void SetDefaults()
		{
			item.noWet = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 99;
			item.consumable = true;
			item.createTile = TileType<Tiles.GravityCandelabra>();
			item.width = 20;
			item.height = 20;
			item.value = Item.sellPrice(0, 0, 3, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GravityBrick", 5);
			recipe.AddIngredient(ItemID.Torch, 3);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}