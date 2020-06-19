using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.Hardmode
{
	[AutoloadEquip(EquipType.Head)]
	public class ChlorophyteHeadwrap : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("16% increased telekinetic damage\n20% increased telekinetic critical strike chance\n10 increased max psychosis");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.rare = 7;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkDamage += 0.16f;
			ECPlayer.ModPlayer(player).tkCrit += 20;
			ECPlayer.ModPlayer(player).maxPsychosis2 += 10;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.ChlorophytePlateMail && legs.type == ItemID.ChlorophyteGreaves;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Chlorophyte");
			player.AddBuff(BuffID.LeafCrystal, 18000, true);
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
			//player.armorEffectDrawShadowSubtle = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
