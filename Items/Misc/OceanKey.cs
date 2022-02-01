using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Misc
{
	public class OceanKey : ECTagItem
	{
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			if (NPC.downedPlantBoss)
				tooltips.Insert(1, new TooltipLine(mod, "KeyTag", "Unlocks an Ocean Chest in the dungeon"));
			else
				tooltips.Insert(1, new TooltipLine(mod, "KeyTag", "It has been cursed by a powerful Jungle creature"));
		}

		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 18;
			item.maxStack = 99;
			item.rare = 8;
		}
	}
}
