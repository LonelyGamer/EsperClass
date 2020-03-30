using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace EsperClass.UI
{
	public static class ECUI
	{
		//Adapted from Elemental Unleash's Purity Shield Bar UI
		public static void Initialize()
		{
		}

		public static void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			for (int k = 0; k < layers.Count; k++)
			{
				if (layers[k].Name == "Vanilla: Resource Bars")
				{
					layers.Insert(k + 1, new LegacyGameInterfaceLayer("EsperClass: Psychosis Bar", DrawPsychosisBar, InterfaceScaleType.UI));
				}
			}
		}

		private static bool DrawPsychosisBar()
		{
			Player player = Main.player[Main.myPlayer];
			ECPlayer modPlayer = ECPlayer.ModPlayer(player);
			Mod mod = EsperClass.Instance;
			if (!modPlayer.PsychosisFull() || modPlayer.psychosisDelay2 > 0 || player.HasBuff(mod.BuffType("PsychedOut")) && !player.dead)
			{
				Vector2 value = Main.player[Main.myPlayer].Bottom + new Vector2(0f, Main.player[Main.myPlayer].gfxOffY);
				value.X -= (float)(Main.player[Main.myPlayer].width + (20 * Main.UIScale));
				value.Y += 110;
				if (Main.playerInventory && Main.screenHeight < 1000)
				{
					value.Y += (float)(Main.player[Main.myPlayer].height - 20);
				}
				value -= Main.screenPosition;
				//value = Vector2.Transform(value - Main.screenPosition, Main.GameViewMatrix.ZoomMatrix);
				if (!Main.playerInventory || Main.screenHeight >= 1000)
				{
					value.Y -= 100f;
				}
				value /= Main.UIScale;
				if (Main.ingameOptionsWindow || Main.InGameUI.IsVisible)
				{
					value = new Vector2((float)(Main.screenWidth / 2), (float)(Main.screenHeight / 2 + 236));
					if (Main.InGameUI.IsVisible)
					{
						value.Y = (float)(Main.screenHeight - 64);
					}
				}

				float precent = ECPlayer.ModPlayer(player).psychosis / ECPlayer.ModPlayer(player).TotalPsychosis();
				int frameY = 0;
				if (player.FindBuffIndex(mod.BuffType("PsychedOut")) > -1)
				{
					//if (player.FindBuffIndex(mod.BuffType("PsychedOut")) <= 15)
					//	frameY = 234;
					if (Main.time % 10 < 5)
						frameY = 198;
					else
						frameY = 216;
				}
				else
				{
				if (precent >= 1f)
					frameY = 0;
				else if (precent >= 0.9f)
					frameY = 18;
				else if (precent >= 0.8f)
					frameY = 36;
				else if (precent >= 0.7f)
					frameY = 54;
				else if (precent >= 0.6f)
					frameY = 72;
				else if (precent >= 0.5f)
					frameY = 90;
				else if (precent >= 0.4f)
					frameY = 108;
				else if (precent >= 0.3f)
					frameY = 126;
				else if (precent >= 0.2f)
					frameY = 144;
				else if (precent >= 0.1f)
					frameY = 162;
				else if (precent >= 0f)
					frameY = 180;
				else
					frameY = 234;
				}
				Main.spriteBatch.Draw(mod.GetTexture("UI/PsychosisMeter"), value, new Rectangle(0, frameY, 74, 18), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
				const int chargeHeight = 20;
				DynamicSpriteFont font = Main.fontMouseText;
				string psychosisText = (int)ECPlayer.ModPlayer(player).psychosis + " / " + ECPlayer.ModPlayer(player).TotalPsychosis();
				Vector2 maxTextSize = font.MeasureString(psychosisText);
				Color textColor = new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor);
				Main.spriteBatch.DrawString(font, psychosisText, new Vector2(value.X + 40 + maxTextSize.X / 2f, value.Y + 20f), textColor, 0f, new Vector2(font.MeasureString(psychosisText).X, 0f), 1f, SpriteEffects.None, 0f);
			}
			return true;
		}

		public static Rectangle GetFullRectangle(UIElement element)
		{
			CalculatedStyle dim = element.GetDimensions();
			return GetFullRectangle((int)dim.X, (int)dim.Y, (int)dim.Width, (int)dim.Height);
		}

		public static Rectangle GetFullRectangle(int x, int y, int width, int height)
		{
			Vector2 vector = new Vector2(x, y);
			Vector2 position = new Vector2(width, height) + vector;
			vector = Vector2.Transform(vector, Main.UIScaleMatrix);
			position = Vector2.Transform(position, Main.UIScaleMatrix);
			Rectangle result = new Rectangle((int)vector.X, (int)vector.Y, (int)(position.X - vector.X), (int)(position.Y - vector.Y));
			int sWidth = Main.spriteBatch.GraphicsDevice.Viewport.Width;
			int sHeight = Main.spriteBatch.GraphicsDevice.Viewport.Height;
			result.X = Utils.Clamp<int>(result.X, 0, sWidth);
			result.Y = Utils.Clamp<int>(result.Y, 0, sHeight);
			result.Width = Utils.Clamp<int>(result.Width, 0, sWidth - result.X);
			result.Height = Utils.Clamp<int>(result.Height, 0, sHeight - result.Y);
			return result;
		}
	}
}
