using EsperClass;
using EsperClass.Items;
using EsperClass.Projectiles;
using EsperClass.Buffs;
using EsperClass.UI;
using Microsoft.Xna.Framework;
﻿using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

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
			Mod LootBags = ModLoader.GetMod("LootBags");
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
			Main.NewText("Size: " + TKItem.Count, 255, 192, 203);
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
