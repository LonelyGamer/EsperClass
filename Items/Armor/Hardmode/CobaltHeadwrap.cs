using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.Hardmode
{
	[AutoloadEquip(EquipType.Head)]
	public class CobaltHeadwrap : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("15% increased telekinetic damage\n10% increased telekinetic critical strike chance");
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
			ECPlayer.ModPlayer(player).tkDamage += 0.15f;
			ECPlayer.ModPlayer(player).tkCrit += 10;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "8 increased psychosis";
			ECPlayer.ModPlayer(player).maxPsychosis2 += 8;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
