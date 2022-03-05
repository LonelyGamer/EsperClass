using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Tiles
{
	public class TrappedGravityChest : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Trapped Gravity Chest");
			AddMapEntry(new Color(255, 206, 49), name);
			dustType = 162;
			disableSmartCursor = true;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 32, ItemType<Items.Placeables.TrappedGravityChest>());
		}

		public override bool HasSmartInteract()
		{
			return true;
		}

		public override bool NewRightClick(int x, int y)
		{
			int j = Main.tile[x, y].frameX / 18;
			j = x - j;
			int num8 = y - Main.tile[x, y].frameY / 18;
			Animation.NewTemporaryAnimation(2, Main.tile[x, y].type, j, num8);
			NetMessage.SendTemporaryAnimation(-1, 2, Main.tile[x, y].type, j, num8);
			Wiring.HitSwitch(x, y);
			Use(x, y);
			NetMessage.SendData(59, -1, -1, null, x, y);
			return true;
		}

		public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.showItemIcon = true;
			player.showItemIcon2 = ItemType<Items.Placeables.TrappedGravityChest>();
		}

		public static void Use(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			int num6 = Main.tile[i, j].frameX / 18 * -1;
			int num5 = Main.tile[i, j].frameY / 18 * -1;
			num6 %= 4;
			if (num6 < -1)
			{
				num6 += 2;
			}
			num6 += i;
			num5 += j;
			Main.PlaySound(28, i * 16, j * 16, 0);
			Wiring.TripWire(num6, num5, 2, 2);
			int num = i;
			if (tile.frameX % 36 != 0)
			{
				num--;
			}
		}

		public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
		{
			Tile tile = Main.tile[i, j];
			int left = i;
			int top = j;
			if (tile.frameX % 36 != 0)
				left--;
			if (tile.frameY != 0)
				top--;
			if (Animation.GetTemporaryFrame(left, top, out int num264))
				frameYOffset = (short)(38 * num264);
		}
	}
}