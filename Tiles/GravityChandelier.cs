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
	public class GravityChandelier : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.tileNoAttach[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 1, 1);
			TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
			TileObjectData.newTile.Origin = new Point16(1, 0);
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			disableSmartCursor = true;
			TileObjectData.addTile(Type);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Gravity Chandelier");
			adjTiles = new int[] { TileID.Torches };

			AddMapEntry(new Color(255, 206, 49), name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 32, ItemType<Items.Placeables.GravityChandelier>());
		}

		public override void HitWire(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			int topY;
			for (topY = tile.frameY / 18; topY >= 3; topY -= 3)
			{
			}
			int num138 = j - topY;
			int num137 = tile.frameX % 108 / 18;
			if (num137 > 2)
			{
				num137 -= 3;
			}
			num137 = i - num137;
			short num135 = 54;
			if (Main.tile[num137, num138].frameX % 108 > 0)
			{
				num135 = -54;
			}
			for (int num134 = num137; num134 < num137 + 3; num134++)
			{
				for (int num133 = num138; num133 < num138 + 3; num133++)
				{
					Main.tile[num134, num133].frameX += num135;
					Wiring.SkipWire(num134, num133);
				}
			}
			NetMessage.SendTileSquare(-1, num137 + 1, num138 + 1, 3);
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

		/*public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			SpriteEffects effects = SpriteEffects.None;
			if (i % 2 == 1)
			{
				effects = SpriteEffects.FlipHorizontally;
			}

			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}

			Tile tile = Main.tile[i, j];
			int width = 16;
			int offsetY = 0;
			int height = 16;
			TileLoader.SetDrawPositions(i, j, ref width, ref offsetY, ref height);
		}*/
	}
}
