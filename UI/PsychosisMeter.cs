using EsperClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.UI
{
	internal class PsychosisMeter : UIState
	{
		public override void Draw(SpriteBatch spriteBatch) //Adapted from Example Mod's ExampleResourceBar
		{
			Player player = Main.player[Main.myPlayer];
			var modPlayer = Main.LocalPlayer.GetModPlayer<ECPlayer>();
			if (!(!modPlayer.PsychosisFull() || modPlayer.psychosisDelay2 > 0 || player.HasBuff(BuffType<Buffs.PsychedOut>()) && !player.dead))
				return;
			base.Draw(spriteBatch);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch) //Adapted from breath meter code
		{
			base.DrawSelf(spriteBatch);
			Player player = Main.player[Main.myPlayer];
			var modPlayer = Main.LocalPlayer.GetModPlayer<ECPlayer>();
			if (!(!modPlayer.PsychosisFull() || modPlayer.psychosisDelay2 > 0 || player.HasBuff(BuffType<Buffs.PsychedOut>()) && !player.dead))
				return;
			//Thanks to Verveine for the revamped code
			Vector2 vector = (player.position + new Vector2(player.width * 0.5f, player.gravDir > 0 ? player.height - 10 + player.gfxOffY : 10 + player.gfxOffY)).Floor();
			vector = Vector2.Transform(vector - Main.screenPosition, Main.GameViewMatrix.EffectMatrix * Main.GameViewMatrix.ZoomMatrix) / Main.UIScale;

			this.Left.Set(vector.X, 0f);
			this.Top.Set(vector.Y, 0f);

			CalculatedStyle dimensions = GetDimensions();
			Point value = new Point((int)dimensions.X, (int)dimensions.Y);

			float precent = modPlayer.psychosis / modPlayer.TotalPsychosis();
			int frameY = 0;
			if (player.HasBuff(BuffType<Buffs.PsychedOut>()))
			{
				//if (player.FindBuffIndex(mod.BuffType("PsychedOut")) <= 15)
				//	frameY = 234;
				if (modPlayer.playerTic < 5)
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

			Main.spriteBatch.Draw(GetTexture("EsperClass/UI/PsychosisMeter"), new Vector2(value.X - 40, value.Y + 20f), new Rectangle(0, frameY, 74, 18), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			DynamicSpriteFont font = Main.fontMouseText;
			string psychosisText = (int)ECPlayer.ModPlayer(player).psychosis + " / " + ECPlayer.ModPlayer(player).TotalPsychosis();
			Vector2 maxTextSize = font.MeasureString(psychosisText);
			Color textColor = new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor);
			Main.spriteBatch.DrawString(font, psychosisText, new Vector2(value.X + maxTextSize.X / 2f, value.Y + 40f), textColor, 0f, new Vector2(font.MeasureString(psychosisText).X, 0f), 1f, SpriteEffects.None, 0f);
			if (ECPlayer.ModPlayer(player).lihzahrdSetBonus)
			{
				float precent2 = modPlayer.lihzahrdPower / 30f;
				if (precent2 <= 0f)
					frameY = 0;
				else if (precent2 <= 0.1f)
					frameY = 18;
				else if (precent2 <= 0.2f)
					frameY = 36;
				else if (precent2 <= 0.3f)
					frameY = 54;
				else if (precent2 <= 0.4f)
					frameY = 72;
				else if (precent2 <= 0.5f)
					frameY = 90;
				else if (precent2 <= 0.6f)
					frameY = 108;
				else if (precent2 <= 0.7f)
					frameY = 126;
				else if (precent2 <= 0.8f)
					frameY = 144;
				else if (precent2 <= 0.9f)
					frameY = 162;
				else if (precent2 <= 1f)
					frameY = 180;
				Main.spriteBatch.Draw(GetTexture("EsperClass/UI/PsychosisMeterExtra"), new Vector2(value.X - 40, value.Y + 20f), new Rectangle(0, frameY, 74, 18), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			}
			//spriteBatch.Draw(bubbleTexture, value + new Vector2((float)(26 * (j - 1) + num20) - 125f, 32f + ((float)bubbleTexture.Height - (float)bubbleTexture.Height * num23) / 2f + (float)num19), new Rectangle(0, 0, bubbleTexture.Width, bubbleTexture.Height), new Color(num22, num22, num22, num22), 0f, default(Vector2), num23, SpriteEffects.None, 0f);
		}

		/*public override void Update(GameTime gameTime)
		{
			Player player = Main.player[Main.myPlayer];
			var modPlayer = Main.LocalPlayer.GetModPlayer<ECPlayer>();
			if (!modPlayer.PsychosisFull() || modPlayer.psychosisDelay2 > 0 || player.HasBuff(BuffType<Buffs.PsychedOut>()) && !player.dead)
				return;

			// Setting the text per tick to update and show our resource values.
			text.SetText((int)ECPlayer.ModPlayer(player).psychosis + " / " + ECPlayer.ModPlayer(player).TotalPsychosis());
			base.Update(gameTime);
		}*/
	}
}
