using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Materials
{
	public class GravityFragment : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'The force holding the cosmos together flows from this fragment'");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = 9;
		}
	}
}
