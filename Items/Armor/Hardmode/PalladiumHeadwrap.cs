using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.Hardmode
{
	[AutoloadEquip(EquipType.Head)]
	public class PalladiumHeadwrap : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("16% increased telekinetic damage\n11% increased telekinetic critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 75000;
			item.rare = 4;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkDamage += 0.16f;
			ECPlayer.ModPlayer(player).tkCrit += 11;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.PalladiumBreastplate && legs.type == ItemID.PalladiumLeggings;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Palladium");
			player.onHitRegen = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PalladiumBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
