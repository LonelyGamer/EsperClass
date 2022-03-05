using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Tiles
{
	public class GravityCandle : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
			TileObjectData.addTile(Type);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Gravity Candle");
			adjTiles = new int[] { TileID.Torches };
			TileObjectData.newTile.CoordinateHeights = new int[1]
			{
				20
			};
			TileObjectData.newTile.DrawYOffset = -2;

			AddMapEntry(new Color(255, 206, 49), name);
		}

		public override bool Drop(int i, int j)
		{
			Item.NewItem(i * 16, j * 16, 16, 16, ItemType<Items.Placeables.GravityCandle>());
			return base.Drop(i, j);
		}

		//Copied from Wiring.cs
		public override void HitWire(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			short num74 = 18;
			if (tile.frameX > 0)
			{
				num74 = -18;
			}
			tile.frameX += num74;
			NetMessage.SendTileSquare(-1, i, j, 3);
			/*short frameAdjustment = (short)(tile.frameX > 0 ? -18 : 18);
			Main.tile[i, j].frameX += frameAdjustment;
			Wiring.SkipWire(i, j);
			NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);*/
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			Tile tile = Main.tile[i, j];
			if (tile.frameX == 0)
			{
				r = 1f;
				g = 0.808f;
				b = 0.192f;
			}
		}
	}
}
