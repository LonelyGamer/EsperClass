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
	public class GravityCandelabra : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(Type);
			TileObjectData.newTile.Origin = new Point16(1, 1);
			TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Gravity Candelabra");
			adjTiles = new int[] { TileID.Torches };

			AddMapEntry(new Color(255, 206, 49), name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 32, ItemType<Items.Placeables.GravityCandelabra>());
		}

		public override void HitWire(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			int topY;
			for (topY = tile.frameY / 18; topY >= 2; topY -= 2)
			{
			}
			topY = j - topY;
			int topX = tile.frameX / 18;
			if (topX > 1)
			{
				topX -= 2;
			}
			topX = i - topX;
			short frameAdjustment = 36;
			if (Main.tile[topX, topY].frameX > 0)
			{
				frameAdjustment = -36;
			}
			Main.tile[topX, topY].frameX += frameAdjustment;
			Main.tile[topX, topY + 1].frameX += frameAdjustment;
			Main.tile[topX + 1, topY].frameX += frameAdjustment;
			Main.tile[topX + 1, topY + 1].frameX += frameAdjustment;
			Wiring.SkipWire(topX, topY);
			Wiring.SkipWire(topX + 1, topY);
			Wiring.SkipWire(topX, topY + 1);
			Wiring.SkipWire(topX + 1, topY + 1);
			NetMessage.SendTileSquare(-1, topX, topY, 3);
		}

		/*public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
		{
			if (i % 2 == 1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}*/

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			Tile tile = Main.tile[i, j];
			if (tile.frameX < 36)
			{
				r = 1f;
				g = 0.808f;
				b = 0.192f;
			}
		}
	}
}
