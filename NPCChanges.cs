using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass
{
	public class NPCChanges : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			//Drop psychosis refills
			if (npc.type != NPCID.MotherSlime && npc.type != NPCID.CorruptSlime && npc.type != NPCID.Slimer && npc.lifeMax > 1 && npc.damage > 0)
			{
				int nearestPlayer = (int)Player.FindClosest(npc.position, npc.width, npc.height);
				ECPlayer modPlayer = Main.player[nearestPlayer].GetModPlayer<ECPlayer>();
				if (Main.rand.Next(5) == 0 && !modPlayer.PsychosisFull())
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PsychicEye"), 1, false, 0, false, false);
				}
			}

			if (npc.type == NPCID.KingSlime && !Main.expertMode)
			{
				if (Main.rand.Next(3) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SlimyCanister"));
			}
			if (npc.type == NPCID.EyeofCthulhu && !Main.expertMode)
			{
				if (Main.rand.Next(3) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EyeJar"));
			}
			if (npc.type == NPCID.GoblinPeon || npc.type == NPCID.GoblinThief || npc.type == NPCID.GoblinWarrior || npc.type == NPCID.GoblinSorcerer || npc.type == NPCID.GoblinArcher)
			{
				int chance = 100;
				if (Main.expertMode)
					chance = 50;
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpikyBallLobber"));
			}
			if (npc.type == NPCID.WallofFlesh && !Main.expertMode)
			{
				if (Main.rand.Next(4) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EsperEmblem"));
				if (Main.rand.Next(4) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GiantGear"));
			}
			if (npc.type == NPCID.Pixie)
			{
				int chance = 40;
				if (Main.expertMode)
					chance = 20;
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PixieJar"));
			}
			if (npc.type == NPCID.WyvernHead)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WyvernScale"));
			}
			if (npc.type == NPCID.GoblinSummoner)
			{
				int chance = 6;
				if (Main.expertMode)
					chance = 3;
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowflameRift"));
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowflameVialNecklace"));
			}
			if (npc.type == NPCID.MisterStabby || npc.type == NPCID.SnowmanGangsta || npc.type == NPCID.SnowBalla)
			{
				int chance = 6;
				if (Main.expertMode)
					chance = 3;
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SnowmanBoulder"), Main.rand.Next(5, 8));
			}
			if (npc.type == NPCID.PirateShip)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TKCannonball"), Main.rand.Next(30, 40));
				int chance = 6;
				if (Main.expertMode)
					chance = 3;
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MidasVialNecklace"));
			}
			if (npc.type == NPCID.Mimic && npc.ai[3] == 4f && npc.value > 0)
			{
				if (Main.rand.Next(2) == 0 || Main.expertMode)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlizzardTwirler"));
			}
			if (npc.type == NPCID.BigMimicCorruption)
			{
				int chance = 4;
				if (Main.expertMode)
					chance = 2;
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedFlameOrbit"));
			}
			if (npc.type == NPCID.BigMimicCrimson)
			{
				int chance = 4;
				if (Main.expertMode)
					chance = 2;
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IchorBomber"));
			}
			if (npc.type == NPCID.BigMimicHallow)
			{
				int chance = 4;
				if (Main.expertMode)
					chance = 2;
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CrystalFlail"));
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CrystalGrenade"));
			}
			/*if (npc.type == NPCID.LunarTowerSolar || npc.type == NPCID.LunarTowerVortex || npc.type == NPCID.LunarTowerNebula || npc.type == NPCID.LunarTowerStardust)
			{
				int amount;
				if (Main.expertMode)
					amount = Main.rand.Next(12, 23);
				else
					amount = Main.rand.Next(8, 15);
				for (int i = 0; i < amount; i++)
				{
					Item.NewItem((int)npc.position.X + Main.rand.Next(npc.width), (int)npc.position.Y + Main.rand.Next(npc.height), 2, 2, mod.ItemType("GravityFragment"), Main.rand.Next(1, 4), false, 0, false, false);
				}
			}*/
		}
		
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.SkeletonMerchant)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("SkeletonBoneLauncher"));
				nextSlot++;
			}
		}

		public override void SetupTravelShop(int[] shop, ref int nextSlot)
		{
			if (NPC.downedBoss1 && Main.rand.Next(3) == 0)
			{
				shop[nextSlot] = mod.ItemType("BowlingBall");
				nextSlot++;
			}
		}
	}
}
