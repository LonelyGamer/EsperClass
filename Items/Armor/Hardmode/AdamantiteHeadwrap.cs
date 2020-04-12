using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.Hardmode
{
	[AutoloadEquip(EquipType.Head)]
	public class AdamantiteHeadwrap : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("21% increased telekinetic damage\n14% increased telekinetic critical strike chance");
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
			ECPlayer.ModPlayer(player).tkDamage += 0.21f;
			ECPlayer.ModPlayer(player).tkCrit += 14;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "12 increased psychosis";
			ECPlayer.ModPlayer(player).maxPsychosis2 += 12;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
