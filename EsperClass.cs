using System;
using System.Collections.Generic;
using System.IO;
using EsperClass.UI;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace EsperClass
{
    public class EsperClass : Mod
	{
		public static Mod Instance;
		public static List<int> TKItem = new List<int>();
		public static List<int> TKProjectile = new List<int>();

		//public static DynamicSpriteFont exampleFont;

		private UserInterface _psychosisMeterUserInterface;

		internal PsychosisMeter PsychosisMeter;

		public EsperClass()
		{
		}

		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => "Copper or Tin Bar", new int[] { ItemID.CopperBar, ItemID.TinBar }); RecipeGroup.RegisterGroup("EsperClass:Tier1Bar", group);
			group = new RecipeGroup(() => "Silver or Tungsten Bar", new int[] { ItemID.SilverBar, ItemID.TungstenBar }); RecipeGroup.RegisterGroup("EsperClass:Tier3Bar", group);
			group = new RecipeGroup(() => "Gold or Platinum Bar", new int[] { ItemID.GoldBar, ItemID.PlatinumBar }); RecipeGroup.RegisterGroup("EsperClass:Tier4Bar", group);
			group = new RecipeGroup(() => "Demonite or Crimtane Bar", new int[] { ItemID.DemoniteBar, ItemID.CrimtaneBar }); RecipeGroup.RegisterGroup("EsperClass:Tier5Bar", group);
		}

		public override void Load()
		{
			Instance = this;
			//TKItem = TKItem;
			if (!Main.dedServ)
			{
				// Custom Resource Bar
				PsychosisMeter = new PsychosisMeter();
				_psychosisMeterUserInterface = new UserInterface();
				_psychosisMeterUserInterface.SetState(PsychosisMeter);
			}
		}

		public override void Unload()
		{
			// Unload static references
			// You need to clear static references to assets (Texture2D, SoundEffects, Effects).
			// In addition to that, if you want your mod to completely unload during unload, you need to clear static references to anything referencing your Mod class
			Instance = null;
		}

		public override void UpdateUI(GameTime gameTime)
		{
			_psychosisMeterUserInterface?.Update(gameTime);
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
			if (resourceBarIndex != -1)
			{
				layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer("EsperClass: Psychosis Meter",
					delegate
					{
						_psychosisMeterUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}

		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			EsperClassMessageType msgType = (EsperClassMessageType)reader.ReadByte();
			switch (msgType)
			{
				case EsperClassMessageType.ECPlayerSyncPlayer:
				{
					byte playernumber = reader.ReadByte();
					ECPlayer ecplayer = Main.player[playernumber].GetModPlayer<ECPlayer>();
					float psychosis = reader.ReadSingle();
					ecplayer.psychosis = psychosis;
					/*int psychosisDelay = reader.ReadInt32();
					ecplayer.psychosisDelay = psychosisDelay;
					int psychosisDelay2 = reader.ReadInt32();
					ecplayer.psychosisDelay2 = psychosisDelay2;
					int maxPsychosis = reader.ReadInt32();
					ecplayer.maxPsychosis = maxPsychosis;
					bool psychosisWarning = reader.ReadInt32();
					ecplayer.psychosisWarning = psychosisWarning;
					ecplayer.nonStopParty = reader.ReadBoolean();*/
					// SyncPlayer will be called automatically, so there is no need to forward this data to other clients.
					break;
				}
				case EsperClassMessageType.psychosis:
				{
					byte playernumber = reader.ReadByte();
					ECPlayer ecPlayer = Main.player[playernumber].GetModPlayer<ECPlayer>();
					float psychosis = reader.ReadSingle();
					ecPlayer.psychosis = psychosis;
					break;
				}
				default:
				{
					Logger.WarnFormat("EsperClass: Unknown Message type: {0}", msgType);
					break;
				}
			}
		}

		public override void PostSetupContent()
		{
			/*Mod LootBags = ModLoader.GetMod("LootBags");
			if (LootBags != null)
			{
				//Player player = Main.player[Main.myPlayer];
				//if (ECPlayer.ModPlayer(player).maxPsychosis > 10)
				//{
				LootBags.Call(.05, ItemType("TKBoulder"), 20, 30, 1);
				LootBags.Call(.05, ItemType("MoltenBoulder"), 20, 30, 2);
				LootBags.Call(.05, ItemType("SnowmanBoulder"), 20, 30, 3);
				LootBags.Call(.05, ItemType("TKThornBall"), 20, 30, 4);
				//}
			}
			Main.NewText("Size: " + TKItem.Count, 255, 192, 203);*/
            Mod wWeaponScaling = ModLoader.GetMod("WWeaponScaling"); // Checks whether the Weapon Scaling mod is loaded
            if (wWeaponScaling != null)
            {
				/*WEAPON TIERS
				1 = Wooden
				2 = Iron
				3 = Gold
				4 = Evil
				5 = Jungle
				6 = Dungeon
				7 = Molten
				8 = Adamantite
				9 = Hallowed
				10 = Chlorophyte
				11 = Post-Plantera
				12 = Post-Golem
				13 = Lunar
				14 = Moon Lord*/

				//wWeaponScaling.Call(WEAPON ID, TIER, SCALING FACTOR);
				//WEAPON ID is the internal ID of the weapon to be added to the database of supported weapons.
				//TIER is the starting tier of said weapon. For example, if it is obtained in the post-skeletron dungeon, it would be tier 6. Refer to the table above.
				//SCALING FACTOR is how much of the scaling multiplier is applied to the weapon. 1f is the default.
				//    If the weapon scales too much at higher tiers, lower the number into decimals until it feels right. Increase if the weapon scales too slowly.

				wWeaponScaling.Call(ItemType("WoodenDisc"), 1, 1f);
				wWeaponScaling.Call(ItemType("BorealWoodDisc"), 1, 1f);
				wWeaponScaling.Call(ItemType("CactusBall"), 1, 1f);
				wWeaponScaling.Call(ItemType("PalmWoodDisc"), 1, 1f);
				wWeaponScaling.Call(ItemType("RichMahoganyDisc"), 1, 1f);
				wWeaponScaling.Call(ItemType("EbonwoodDisc"), 1, 1f);
				wWeaponScaling.Call(ItemType("ShadewoodDisc"), 1, 1f);
				wWeaponScaling.Call(ItemType("DynastyWoodDisc"), 1, 1f);
				wWeaponScaling.Call(ItemType("CopperSawblade"), 1, 1f);
				wWeaponScaling.Call(ItemType("TinSawblade"), 1, 1f);
				wWeaponScaling.Call(ItemType("TorchTwirler"), 1, 1f);
				wWeaponScaling.Call(ItemType("FrostburnTwirler"), 1, 1f);

				wWeaponScaling.Call(ItemType("PearlwoodDisc"), 2, 1f);
				wWeaponScaling.Call(ItemType("IronSawblade"), 2, 1f);
				wWeaponScaling.Call(ItemType("LeadSawblade"), 2, 1f);
				wWeaponScaling.Call(ItemType("SilverSawblade"), 2, 1f);
				wWeaponScaling.Call(ItemType("TungstenSawblade"), 2, 1f);
				wWeaponScaling.Call(ItemType("AmethystRift"), 2, 1f);
				wWeaponScaling.Call(ItemType("TopazRift"), 2, 1f);
				wWeaponScaling.Call(ItemType("SapphireRift"), 2, 1f);
				wWeaponScaling.Call(ItemType("EmeraldRift"), 2, 1f);
				wWeaponScaling.Call(ItemType("PinkyTwirler"), 2, 1f);

				wWeaponScaling.Call(ItemType("GoldSawblade"), 3, 1f);
				wWeaponScaling.Call(ItemType("PlatinumSawblade"), 3, 1f);
				wWeaponScaling.Call(ItemType("EnchantedSawblade"), 3, 1f);
				wWeaponScaling.Call(ItemType("RubyRift"), 3, 1f);
				wWeaponScaling.Call(ItemType("DiamondRift"), 3, 1f);
				wWeaponScaling.Call(ItemType("NoviceSawblade"), 3, 1f);
				wWeaponScaling.Call(ItemType("BrightTwirler"), 3, 1f);
				wWeaponScaling.Call(ItemType("BoneTwirler"), 3, 1f);
				wWeaponScaling.Call(ItemType("SlimyCanister"), 3, 1f);
				wWeaponScaling.Call(ItemType("PinkSlimyCanister"), 3, 1f);
				wWeaponScaling.Call(ItemType("BatJar"), 3, 1f);
				wWeaponScaling.Call(ItemType("SpittingSandfish"), 3, 1f);

				wWeaponScaling.Call(ItemType("DemoniteSawblade"), 4, 1f);
				wWeaponScaling.Call(ItemType("DemoniteCanister"), 4, 1f);
				wWeaponScaling.Call(ItemType("EbonCactusBall"), 4, 1f);
				wWeaponScaling.Call(ItemType("CrimtaneSawblade"), 4, 1f);
				wWeaponScaling.Call(ItemType("CrimtaneCanister"), 4, 1f);
				wWeaponScaling.Call(ItemType("CrimCactusBall"), 4, 1f);
				wWeaponScaling.Call(ItemType("ShadowOrbit"), 4, 1f);
				wWeaponScaling.Call(ItemType("ClotBomber"), 4, 1f);
				wWeaponScaling.Call(ItemType("EyeJar"), 4, 1f);
				wWeaponScaling.Call(ItemType("DemonTwirler"), 4, 1f);
				wWeaponScaling.Call(ItemType("FeatherGust"), 4, 1f);
				wWeaponScaling.Call(ItemType("TKBoulder"), 4, 1f);
				wWeaponScaling.Call(ItemType("SpikyBallLobber"), 4, 1f);
				wWeaponScaling.Call(ItemType("BowlingBall"), 4, 1f);

				wWeaponScaling.Call(ItemType("TKMeteor"), 5, 1f);
				wWeaponScaling.Call(ItemType("JungleSawblade"), 5, 1f);
				wWeaponScaling.Call(ItemType("JungleCanister"), 5, 1f);
				wWeaponScaling.Call(ItemType("AmberRift"), 5, 1f);
				wWeaponScaling.Call(ItemType("BeeJar"), 5, 1f);

				wWeaponScaling.Call(ItemType("DungeonSawblade"), 6, 1f);
				wWeaponScaling.Call(ItemType("DungeonCanister"), 6, 1f);

				wWeaponScaling.Call(ItemType("HellstoneSawblade"), 7, 1f);
				wWeaponScaling.Call(ItemType("HellstoneCanister"), 7, 1f);
				wWeaponScaling.Call(ItemType("MoltenBoulder"), 7, 1f);
				wWeaponScaling.Call(ItemType("HellbatJar"), 7, 1f);
				wWeaponScaling.Call(ItemType("NightSawblade"), 7, 1f);
				wWeaponScaling.Call(ItemType("NightCanister"), 7, 1f);
				wWeaponScaling.Call(ItemType("ApprenticeSawblade"), 7, 1f);
	
				wWeaponScaling.Call(ItemType("GiantGear"), 7, 1f);
				wWeaponScaling.Call(ItemType("CobaltSawblade"), 7, 1f);
				wWeaponScaling.Call(ItemType("PalladiumSawblade"), 7, 1f);
				wWeaponScaling.Call(ItemType("MythrilSawblade"), 7, 1f);
				wWeaponScaling.Call(ItemType("OrichalcumSawblade"), 7, 1f);

				wWeaponScaling.Call(ItemType("AdamantiteSawblade"), 8, 1f);
				wWeaponScaling.Call(ItemType("TitaniumSawblade"), 8, 1f);
				wWeaponScaling.Call(ItemType("LiquidNitrogenCanister"), 8, 1f);
				wWeaponScaling.Call(ItemType("IchorCanister"), 8, 1f);
				wWeaponScaling.Call(ItemType("PrismRift"), 8, 1f);
				wWeaponScaling.Call(ItemType("ShadowflameRift"), 8, 1f);
				wWeaponScaling.Call(ItemType("CursedBouncer"), 8, 1f);
				wWeaponScaling.Call(ItemType("CursedTwirler"), 8, 1f);
				wWeaponScaling.Call(ItemType("IchorTwirler"), 8, 1f);
				wWeaponScaling.Call(ItemType("RainbowTwirler"), 8, 1f);
				wWeaponScaling.Call(ItemType("BlizzardTwirler"), 8, 1f);
				wWeaponScaling.Call(ItemType("SnowmanBoulder"), 8, 1f);
				wWeaponScaling.Call(ItemType("PixieJar"), 8, 1f);
				wWeaponScaling.Call(ItemType("SuperSpittingSandfish"), 8, 1f);
				wWeaponScaling.Call(ItemType("ForbiddenGust"), 8, 1f);
				wWeaponScaling.Call(ItemType("CursedFlameOrbit"), 8, 1f);
				wWeaponScaling.Call(ItemType("IchorBomber"), 8, 1f);
				wWeaponScaling.Call(ItemType("SkeletonBoneLobber"), 8, 1f);
				wWeaponScaling.Call(ItemType("TKCannonball"), 8, 1f);
				wWeaponScaling.Call(ItemType("RedTKRocket"), 8, 1f);
				wWeaponScaling.Call(ItemType("GreenTKRocket"), 8, 1f);
				wWeaponScaling.Call(ItemType("YellowTKRocket"), 8, 1f);
				wWeaponScaling.Call(ItemType("BlueTKRocket"), 8, 1f);
				wWeaponScaling.Call(ItemType("AdeptSawblade"), 8, 1f);
				wWeaponScaling.Call(ItemType("CrystalFlail"), 8, 1f);
				wWeaponScaling.Call(ItemType("CrystalGrenade"), 8, 1f);

				wWeaponScaling.Call(ItemType("HallowedSawblade"), 9, 1f);
				wWeaponScaling.Call(ItemType("HallowedCanister"), 9, 1f);
				wWeaponScaling.Call(ItemType("PearlCactusBall"), 9, 1f);
				wWeaponScaling.Call(ItemType("TKPrimeCannon"), 9, 1f);
				wWeaponScaling.Call(ItemType("TKPrimeSaw"), 9, 1f);
				wWeaponScaling.Call(ItemType("TKPrimeVice"), 9, 1f);
				wWeaponScaling.Call(ItemType("TKPrimeLaser"), 9, 1f);
				wWeaponScaling.Call(ItemType("DeadDoll"), 9, 1f);

				wWeaponScaling.Call(ItemType("ChlorophyteSawblade"), 10, 1f);
				wWeaponScaling.Call(ItemType("ChlorophyteCanister"), 10, 1f);
				wWeaponScaling.Call(ItemType("TrueNightSawblade"), 10, 1f);
				wWeaponScaling.Call(ItemType("TrueHallowedSawblade"), 10, 1f);
				wWeaponScaling.Call(ItemType("TrueNightCanister"), 10, 1f);
				wWeaponScaling.Call(ItemType("TrueHallowedCanister"), 10, 1f);
				wWeaponScaling.Call(ItemType("EpicSawblade"), 10, 1f);

				wWeaponScaling.Call(ItemType("TerraSawblade"), 11, 1f);
				wWeaponScaling.Call(ItemType("TerraCanister"), 11, 1f);
				wWeaponScaling.Call(ItemType("SpookyWoodDisc"), 11, 1f);
				wWeaponScaling.Call(ItemType("VenomTwirler"), 11, 1f);
				wWeaponScaling.Call(ItemType("TKThornBall"), 11, 1f);
				wWeaponScaling.Call(ItemType("WaspJar"), 11, 1f);
				wWeaponScaling.Call(ItemType("SpectreRift"), 11, 1f);
				wWeaponScaling.Call(ItemType("PsiSpikeBall"), 11, 1f);
				wWeaponScaling.Call(ItemType("ImpiousBrooch"), 11, 1f);

				wWeaponScaling.Call(ItemType("MourningTwirler"), 12, 1f);
				wWeaponScaling.Call(ItemType("PsiPumpKing"), 12, 1f);
				wWeaponScaling.Call(ItemType("OrnamentsOrbit"), 12, 1f);
				wWeaponScaling.Call(ItemType("PsiExplodingPresent"), 12, 1f);
				wWeaponScaling.Call(ItemType("IcicleSpitter"), 12, 1f);
				wWeaponScaling.Call(ItemType("GolemHeadRift"), 12, 1f);
				wWeaponScaling.Call(ItemType("BeetleJar"), 12, 1f);
				wWeaponScaling.Call(ItemType("LegendarySawblade"), 12, 1f);
				wWeaponScaling.Call(ItemType("MartianPsi"), 12, 1f);
				wWeaponScaling.Call(ItemType("SharknadoRift"), 12, 1f);
				wWeaponScaling.Call(ItemType("BetsyPsi"), 12, 1f);

				wWeaponScaling.Call(ItemType("EldritchEyeJar"), 14, 1f);
				wWeaponScaling.Call(ItemType("GravityPickaxe"), 14, 1f);
				wWeaponScaling.Call(ItemType("GravityHamaxe"), 14, 1f);
				wWeaponScaling.Call(ItemType("GravityAxe"), 14, 1f);
				wWeaponScaling.Call(ItemType("GravityHammer"), 14, 1f);
				wWeaponScaling.Call(ItemType("GravityDrill"), 14, 1f);
				wWeaponScaling.Call(ItemType("GravityChainsaw"), 14, 1f);

				Mod bossChecklist = ModLoader.GetMod("BossChecklist");
				if (bossChecklist != null)
				{
					bossChecklist.Call("AddToBossLoot", "Terraria", "KingSlime", new List<int> {ModContent.ItemType<Items.Weapons.PreHardmode.SlimyCanister>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "EyeofCthulhu", new List<int> {ModContent.ItemType<Items.Weapons.PreHardmode.EyeJar>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "Goblin Army", new List<int> {ModContent.ItemType<Items.Weapons.PreHardmode.SpikyBallLobber>(), ModContent.ItemType<Items.Weapons.Hardmode.ShadowflameRift>(), ModContent.ItemType<Items.Accessories.Hardmode.ShadowflameVialNecklace>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "WallofFlesh", new List<int> {ModContent.ItemType<Items.Weapons.Hardmode.GiantGear>(), ModContent.ItemType<Items.Accessories.Hardmode.EsperEmblem>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "Frost Legion", new List<int> {ModContent.ItemType<Items.Weapons.Hardmode.SnowmanBoulder>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "Pirate Invasion", new List<int> {ModContent.ItemType<Items.Weapons.Hardmode.TKCannonball>(), ModContent.ItemType<Items.Accessories.Hardmode.MidasVialNecklace>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "PirateShip", new List<int> {ModContent.ItemType<Items.Weapons.Hardmode.TKCannonball>(), ModContent.ItemType<Items.Accessories.Hardmode.MidasVialNecklace>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "Solar Eclipse", new List<int> {ModContent.ItemType<Items.Weapons.Hardmode.DeadDoll>(), ModContent.ItemType<Items.Materials.BrokenHeroPsychicParts>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "Plantera", new List<int> {ModContent.ItemType<Items.Weapons.Hardmode.WaspJar>(), ModContent.ItemType<Items.Weapons.Hardmode.TKThornBall>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "Pumpkin Moon", new List<int> {ModContent.ItemType<Items.Weapons.Hardmode.MourningTwirler>(), ModContent.ItemType<Items.Weapons.Hardmode.PsiPumpKing>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "MourningWood", new List<int> {ModContent.ItemType<Items.Weapons.Hardmode.MourningTwirler>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "Pumpking", new List<int> {ModContent.ItemType<Items.Weapons.Hardmode.PsiPumpKing>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "Frost Moon", new List<int> {ModContent.ItemType<Items.Weapons.Hardmode.OrnamentsOrbit>(), ModContent.ItemType<Items.Weapons.Hardmode.PsiExplodingPresent>(), ModContent.ItemType<Items.Weapons.Hardmode.IcicleSpitter>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "Everscream", new List<int> {ModContent.ItemType<Items.Weapons.Hardmode.OrnamentsOrbit>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "SantaNK1", new List<int> {ModContent.ItemType<Items.Weapons.Hardmode.PsiExplodingPresent>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "IceQueen", new List<int> {ModContent.ItemType<Items.Weapons.Hardmode.IcicleSpitter>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "Golem", new List<int> {ModContent.ItemType<Items.Weapons.Hardmode.GolemHeadRift>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "DukeFishron", new List<int> { ModContent.ItemType<Items.Weapons.Hardmode.SharknadoRift>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "Martian Madness", new List<int> { ModContent.ItemType<Items.Weapons.Hardmode.MartianPsi>() });
					bossChecklist.Call("AddToBossLoot", "Terraria", "MartianSaucer", new List<int> {ModContent.ItemType<Items.Weapons.Hardmode.MartianPsi>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "DD2Betsy", new List<int> { ModContent.ItemType<Items.Weapons.Hardmode.BetsyPsi>() });
					bossChecklist.Call("AddToBossLoot", "Terraria", "Lunar Event", new List<int> {ModContent.ItemType<Items.Materials.GravityFragment>()});
					bossChecklist.Call("AddToBossLoot", "Terraria", "MoonLord", new List<int> {ModContent.ItemType<Items.Weapons.PostMoonLord.EldritchEyeJar>()});
				}
            }
		}

		//Based on jopojelly's Boss Checklist mod
		public override object Call(params object[] args)
		{
			Player player = Main.player[Main.myPlayer];
			try
			{
				string message = args[0] as string;
				if (message == "IncreaseTelekineticDamage")
				{
					float damageAmount = Convert.ToSingle(args[1]);
					return ECPlayer.ModPlayer(player).tkDamage += damageAmount;
				}
				else if (message == "IncreaseTelekineticCrit")
				{
					float critAmount = Convert.ToSingle(args[1]);
					return ECPlayer.ModPlayer(player).tkCrit += (int)critAmount;
				}
				else if (message == "IncreaseTelekineticVelocity")
				{
					float velAmount = Convert.ToSingle(args[1]);
					return ECPlayer.ModPlayer(player).tkVel += velAmount;
				}
				else if (message == "UseTelekineticVelocity")
				{
					return Convert.ToSingle(ECPlayer.ModPlayer(player).tkVel);
				}
				else if (message == "AddTKItem")
				{
					float IsTKItem = Convert.ToSingle(args[1]);
					TKItem.Add((int)IsTKItem);
					return "Success";
				}
				else if (message == "AddTKProjectile")
				{
					float IsTKProjectile = Convert.ToSingle(args[1]);
					TKProjectile.Add((int)IsTKProjectile);
					return "Success";
				}
			}
			catch (Exception e)
			{
				Logger.Error("Esper Class Call Error: " + e.StackTrace + e.Message);
			}
			return "Failure";
		}
	}

	internal enum EsperClassMessageType : byte
	{
		ECPlayerSyncPlayer,
		psychosis
	}
}
