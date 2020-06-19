using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.Hardmode
{
	public class VenomVialNecklace : ECTagItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 28;
			item.value = Item.buyPrice(0, 25, 0, 0);
			item.rare = 7;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Enchants telekinesis attacks with venokinesis, enabling a chance to cause 'Venom' on hit");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).venomVial = true;
		}
	}
}
