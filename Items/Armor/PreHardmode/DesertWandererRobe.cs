using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.PreHardmode
{
	[AutoloadEquip(EquipType.Body)]
	public class DesertWandererRobe : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			//DisplayName.SetDefault("Desert Wanderer Tank Top");
			Tooltip.SetDefault("20% increased telekinetic velocity");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 20, 50);
			item.rare = 1;
			item.defense = 4;
		}

		public override void DrawHands(ref bool drawHands, ref bool drawArms)
		{
			drawHands = true;
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkVel += 0.2f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AntlionMandible, 5);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
