using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.PreHardmode
{
	[AutoloadEquip(EquipType.Body)]
	public class CambrianChestplate : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("25% increased telekinetic velocity");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 20, 50);
			item.rare = 2;
			item.defense = 5;
		}

		/*public override void DrawHands(ref bool drawHands, ref bool drawArms)
		{
			drawHands = true;
			drawArms = true;
		}*/

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkVel += 0.25f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FossilOre, 14);
			recipe.AddIngredient(ItemID.Coral, 8);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
