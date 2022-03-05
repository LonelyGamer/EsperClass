using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.Hardmode
{
	[AutoloadEquip(EquipType.Body)]
	public class WyvernScaleVest : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("30% increased throwing and telekinetic velocity");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.rare = 5;
			item.defense = 16;
		}

		public override void DrawHands(ref bool drawHands, ref bool drawArms)
		{
			drawHands = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownVelocity += 0.3f;
			ECPlayer.ModPlayer(player).tkVel += 0.3f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 20);
			recipe.AddIngredient(null, "WyvernScale", 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumBar, 20);
			recipe.AddIngredient(null, "WyvernScale", 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
