using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Armor.PreHardmode
{
	[AutoloadEquip(EquipType.Head)]
	public class CambrianHelmet : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("18% increased telekinetic damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 20, 20);
			item.rare = 2;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			ECPlayer.ModPlayer(player).tkDamage += 0.18f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("CambrianChestplate") && legs.type == mod.ItemType("CambrianGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Free movement in liquid\nTK projectiles no longer slower in liquid";
            player.ignoreWater = true;
            player.accFlipper = true;
			ECPlayer.ModPlayer(player).cambrianSetBonus = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FossilOre, 8);
			recipe.AddIngredient(ItemID.Coral, 6);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
