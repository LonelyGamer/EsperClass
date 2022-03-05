using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace EsperClass.Items.Placeables
{
	public class GravityBrick : GravityFragmentBlock
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			item.createTile = mod.TileType("GravityBrick");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GravityFragment");
			recipe.AddIngredient(ItemID.StoneBlock, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GravityPlatform", 2);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GravityBrickWall", 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
