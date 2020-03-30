using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Armors.PreHardmode
{
	[AutoloadEquip(EquipType.Body)]
	public class TaurusChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("30% increased telekinesis velocity");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = 3;
			item.defense = 5;
		}

		public override void DrawHands(ref bool drawHands, ref bool drawArms)
		{
			drawHands = true;
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkVel += 0.3f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Lens, 5);
			recipe.AddIngredient(ItemID.Bone, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
