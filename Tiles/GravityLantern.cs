﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Tiles
{
    public class GravityLantern : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.addTile(Type);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Gravity Lantern");
			adjTiles = new int[] { TileID.Torches };

			AddMapEntry(new Color(255, 206, 49), name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 32, ItemType<Items.Placeables.GravityLantern>());
		}

		//From Wiring.cs
		public override void HitWire(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			int num145 = tile.frameY / 18;
			int num144 = j - num145;
			short num143 = 18;
			if (tile.frameX > 0)
			{
				num143 = -18;
			}
			Main.tile[i, num144].frameX += num143;
			Main.tile[i, num144 + 1].frameX += num143;
			Wiring.SkipWire(i, num144);
			Wiring.SkipWire(i, num144 + 1);
			NetMessage.SendTileSquare(-1, i, j, 2);
		}

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
		{
			if (i % 2 == 1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
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

		public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex)
		{
			if (!Main.gamePaused && Main.instance.IsActive && (!Lighting.UpdateEveryFrame || Main.rand.NextBool(4)))
			{
				Tile tile = Main.tile[i, j];
				short frameX = tile.frameX;
				short frameY = tile.frameY;
				if (Main.rand.NextBool(40) && frameX == 0)
				{
					int style = frameY / 54;
					if (frameY / 18 % 3 == 0)
					{
						int dustChoice = -1;
						if (style == 0)
						{
							dustChoice = 162;
						}
						if (dustChoice != -1)
						{
							int dust = Dust.NewDust(new Vector2(i * 16 + 4, j * 16 + 2), 4, 4, dustChoice, 0f, 0f, 100, default(Color), 1f);
							if (Main.rand.Next(3) != 0) {
								Main.dust[dust].noGravity = true;
							}
							Main.dust[dust].velocity *= 0.3f;
							Main.dust[dust].velocity.Y = Main.dust[dust].velocity.Y - 1.5f;
						}
					}
				}
			}
		}

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
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
			/*var flameTexture = mod.GetTexture("Tiles/ExampleLamp_Flame");

			ulong num190 = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i);
			for (int c = 0; c < 7; c++)
			{
				float shakeX = Utils.RandomInt(ref num190, -10, 11) * 0.15f;
				float shakeY = Utils.RandomInt(ref num190, -10, 1) * 0.35f;
				Main.spriteBatch.Draw(flameTexture, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(tile.frameX, tile.frameY, width, height), new Color(100, 100, 100, 0), 0f, default(Vector2), 1f, effects, 0f);
			}*/
		}
	}
}
