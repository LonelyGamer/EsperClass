using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.Hardmode
{
	[AutoloadEquip(EquipType.Head)]
	public class TitaniumHeadwrap : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("22% increased telekinetic damage\n15% increased telekinetic critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 150000;
			item.rare = 4;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkDamage += 0.22f;
			ECPlayer.ModPlayer(player).tkCrit += 15;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Titanium");
			player.onHitDodge = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumBar, 13);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
