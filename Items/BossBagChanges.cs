using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items
{
	public class BossBagChanges : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "bossBag")
			{
				if (arg == ItemID.KingSlimeBossBag && Main.rand.Next(2) == 0)
					player.QuickSpawnItem(mod.ItemType("SlimyCanister"));
				if (arg == ItemID.EyeOfCthulhuBossBag && Main.rand.Next(2) == 0)
					player.QuickSpawnItem(mod.ItemType("EyeJar"));
				if (arg == 3324)
				{
					if (Main.rand.Next(3) == 0)
						player.QuickSpawnItem(mod.ItemType("EsperEmblem"));
					if (Main.rand.Next(3) == 0)
						player.QuickSpawnItem(mod.ItemType("GiantGear"));
				}
				if (arg == 3328) //Plantera
				{
					if (Main.rand.Next(2) == 0)
						player.QuickSpawnItem(mod.ItemType("WaspJar"));
					if (Main.rand.Next(2) == 0)
						player.QuickSpawnItem(mod.ItemType("TKThornBall"), Main.rand.Next(80, 120));
				}
			}
            if (context == "lockBox")
            {
				int chance = 2;
				if (Main.hardMode)
					chance = 10;
				if (Main.rand.Next(chance) == 0)
				{
					if (Main.rand.Next(2) == 0)
						player.QuickSpawnItem(mod.ItemType("DungeonSawblade"));
					else
						player.QuickSpawnItem(mod.ItemType("DungeonCanister"));
				}
			}
		}
	}
}
