using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.PostMoonLord
{
	[AutoloadEquip(EquipType.Body)]
	public class GravityRobe : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("50% increased telekinetic velocity\n12% increased telekinetic damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 14, 0, 0);
			item.rare = 10;
			item.defense = 16;
		}

		/*public override void DrawHands(ref bool drawHands, ref bool drawArms)
		{
			drawHands = true;
		}*/

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkVel += 0.5f;
			ECPlayer.ModPlayer(player).tkDamage += 0.12f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 16);
			recipe.AddIngredient(null, "GravityFragment", 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
