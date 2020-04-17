using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.Hardmode
{
	[AutoloadEquip(EquipType.Head)]
	public class HallowedHeadwrap : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("24% increased telekinetic damage\n16% increased telekinetic critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 2, 50, 0);
			item.rare = 5;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkDamage += 0.24f;
			ECPlayer.ModPlayer(player).tkCrit += 16;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.HallowedPlateMail && legs.type == ItemID.HallowedGreaves;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "12 increased psychosis\n50% faster psychosis recovery";
			ECPlayer.ModPlayer(player).maxPsychosis2 += 12;
			ECPlayer.ModPlayer(player).psychosisRec += 0.5f;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
