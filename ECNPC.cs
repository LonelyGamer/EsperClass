using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass
{
	public class ECNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;

		public bool irradiated;

		public override void ResetEffects(NPC npc)
		{
			irradiated = false;
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (irradiated)
			{
				/*if (Main.rand.Next(4) < 3)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, DustType<EtherealFlame>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.NextBool(4))
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}*/
				Lighting.AddLight(npc.position, 0.1f, 0.7f, 0.2f);
			}
		}

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
				int chance = 100;
				if (Main.expertMode)
					chance = 50;
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SnowmanBoulder"));
			}
			if (npc.type == NPCID.PirateShip)
			{
				int chance = 6;
				if (Main.expertMode)
					chance = 3;
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MidasVialNecklace"));
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TKCannonball"));
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
			if (npc.type == NPCID.ThePossessed)
			{
				int chance = 20;
				if (Main.expertMode)
					chance = 10;
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DeadDoll"));
			}
			if (npc.type == NPCID.Mothron)
			{
				int chance = 3;
				if (Main.expertMode)
					chance = 2;
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrokenHeroPsychicParts"));
			}
			if (npc.type == NPCID.Plantera && !Main.expertMode)
			{
				if (Main.rand.Next(3) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WaspJar"));
				if (Main.rand.Next(3) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TKThornBall"));
			}
			if (npc.type >= NPCID.BlueArmoredBones && npc.type <= NPCID.BlueArmoredBonesSword)
			{
				int chance = 100;
				if (Main.expertMode)
					chance = 50;
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PsiSpikeBall"));
			}
			if (npc.type >= NPCID.RustyArmoredBonesAxe && npc.type <= NPCID.RustyArmoredBonesSwordNoArmor)
			{
				int chance = 100;
				if (Main.expertMode)
					chance = 50;
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpectreRift"));
			}
			if (npc.type >= NPCID.HellArmoredBones && npc.type <= NPCID.HellArmoredBonesSword)
			{
				int chance = 100;
				if (Main.expertMode)
					chance = 50;
				if (Main.rand.Next(chance) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ImpiousBrooch"));
			}
			if (Main.pumpkinMoon)
			{
				int wave = NPC.waveNumber;
				int dropRate = (int)((double)(17 - wave) / 1.25);
				if (Main.expertMode)
					wave += 6;
				if (dropRate < 1)
					dropRate = 1;
				if (Main.rand.Next(dropRate) == 0)
				{
					if (npc.type == NPCID.MourningWood)
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MourningTwirler"));
					if (npc.type == NPCID.Pumpking)
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PsiPumpKing"));
				}
			}
			if (Main.snowMoon)
			{
				int wave = NPC.waveNumber;
				int dropRate = (int)((double)(30 - wave) / 2.5);
				if (Main.expertMode)
				{
					wave += 7;
					dropRate -= 2;
				}
				if (dropRate < 1)
					dropRate = 1;
				if (Main.rand.Next(dropRate) == 0)
				{
					if (npc.type == NPCID.Everscream)
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OrnamentsOrbit"));
					if (npc.type == NPCID.SantaNK1)
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PsiExplodingPresent"));
					if (npc.type == NPCID.IceQueen)
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IcicleSpitter"));
				}
			}
			if (npc.type == NPCID.Golem && !Main.expertMode)
			{
				if (Main.rand.Next(3) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GolemHeadRift"));
			}
			if (npc.type == NPCID.DukeFishron && !Main.expertMode)
			{
				if (Main.rand.Next(3) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SharknadoRift"));
				//if (Main.rand.Next(3) == 0)
				//	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BubbleTurret"));
			}
			if (npc.type == NPCID.MartianSaucerCore)
			{
				if (Main.rand.Next(3) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MartianPsi"));
			}
			if (npc.type == NPCID.DD2Betsy && !Main.expertMode)
			{
				if (Main.rand.Next(2) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BetsyPsi"));
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
			if (npc.type == NPCID.LunarTowerVortex)
			{
				int amount = Main.rand.Next(25, 41) / 2;
				if (Main.expertMode)
				{
					amount = (int)((float)amount * 1.5f);
				}
				for (int i = 0; i < amount; i++)
				{
					Item.NewItem((int)npc.position.X + Main.rand.Next(npc.width), (int)npc.position.Y + Main.rand.Next(npc.height), 2, 2, mod.ItemType("GravityFragment"), Main.rand.Next(1, 4));
				}
			}
			if (npc.type == NPCID.MoonLordCore && !Main.expertMode)
			{
				if (Main.rand.Next(2) == 0)
				{
					int randomDrop = Main.rand.Next(3);
					switch (randomDrop)
					{
						case 0:
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EldritchEyeJar"));
							break;
						case 1:
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AccretionDisc"));
							break;
						case 2:
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlackHoleBomb"));
							break;
					}
				}
			}
			/*if (Main.hardMode && npc.value > 0f)
			{
				int dropChance = GetInstance<ECConfigServer>().easierOceanKey ? 1000 : 2500;
				if (Main.rand.Next(dropChance) == 0 && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneBeach)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OceanKey"));
				}
			}*/
		}
		
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.SkeletonMerchant && Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("SkeletonBoneLobber"));
				nextSlot++;
			}
			if (type == NPCID.WitchDoctor && NPC.downedPlantBoss)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("VenomVialNecklace"));
				nextSlot++;
			}
			if (type == NPCID.Wizard)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("MysticalEyeglass"));
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
