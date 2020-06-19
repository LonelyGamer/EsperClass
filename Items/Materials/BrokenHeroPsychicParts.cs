using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Materials
{
	public class BrokenHeroPsychicParts : ECTagItem
	{
		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 18;
			item.maxStack = 999;
			item.rare = 8;
			item.value = Item.sellPrice(0, 2, 0, 0);
		}
	}
}
