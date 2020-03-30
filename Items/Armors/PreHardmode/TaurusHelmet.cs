using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Armors.PreHardmode
{
	[AutoloadEquip(EquipType.Head)]
	public class TaurusHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("20% increased telekinesis damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = 3;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkDamage += 0.2f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("TaurusChestplate") && legs.type == mod.ItemType("TaurusGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "6 increased psychosis";
			ECPlayer.ModPlayer(player).maxPsychosis2 += 6;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BlackLens);
			recipe.AddIngredient(ItemID.Lens, 2);
			recipe.AddIngredient(ItemID.Bone, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
