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
				if (arg == 3324) //Wall of Flesh
				{
					if (Main.rand.Next(3) == 0)
					{
						player.QuickSpawnItem(mod.ItemType("GiantGear"));
						player.QuickSpawnItem(mod.ItemType("EsperEmblem"));
					}
				}
				if (arg == 3328) //Plantera
				{
					if (Main.rand.Next(2) == 0)
						player.QuickSpawnItem(mod.ItemType("WaspJar"));
					if (Main.rand.Next(2) == 0)
						player.QuickSpawnItem(mod.ItemType("TKThornBall"));
				}
				if (arg == 3329 && Main.rand.Next(2) == 0) //Golem
					player.QuickSpawnItem(mod.ItemType("GolemHeadRift"));
				if (arg == 3330) //Duke Fishron
				{
					if (Main.rand.Next(2) == 0)
						player.QuickSpawnItem(mod.ItemType("SharknadoRift"));
					//if (Main.rand.Next(2) == 0)
					//	player.QuickSpawnItem(mod.ItemType("WaterTornado"));
				}
				if (arg == 3860) //Betsy
				{
					if (Main.rand.Next(2) == 0)
						player.QuickSpawnItem(mod.ItemType("BetsyPsi"));
				}
				if (arg == 3332) //Moon Lord
				{
					int randomDrop = Main.rand.Next(3);
					switch (randomDrop)
					{
						case 0:
							player.QuickSpawnItem(mod.ItemType("EldritchEyeJar"));
							break;
						case 1:
							player.QuickSpawnItem(mod.ItemType("AccretionDisc"));
							break;
						case 2:
							player.QuickSpawnItem(mod.ItemType("BlackHoleBomb"));
							break;
					}
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
