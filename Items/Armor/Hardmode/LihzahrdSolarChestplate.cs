using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.Hardmode
{
	[AutoloadEquip(EquipType.Body)]
	public class LihzahrdSolarChestplate : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("40% increased telekinetic velocity");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 6, 0, 0);
			item.rare = 8;
			item.defense = 18;
		}

		public override void DrawHands(ref bool drawHands, ref bool drawArms)
		{
			drawHands = true;
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkVel += 0.4f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 8);
			recipe.AddIngredient(ItemID.Nanites, 4);
			recipe.AddTile(TileID.LihzahrdFurnace);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
