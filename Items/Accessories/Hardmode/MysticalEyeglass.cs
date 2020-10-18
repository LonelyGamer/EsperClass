using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Accessories.Hardmode
{
	public class MysticalEyeglass : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Allows zooming with right click while holding a TK weapon");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 26;
			item.value = Item.buyPrice(0, 20, 0, 0);
			item.rare = 4;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ECPlayer.ModPlayer(player).tkZoom = true;
		}
	}
}
