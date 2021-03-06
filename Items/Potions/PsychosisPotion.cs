using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Potions
{
	public class PsychosisPotion : ECTagItem
	{
		public virtual int restoreAmount => 20;

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Restores 20 psychosis\nTake damage equal to amount of psychosis restored");
		}

		public override void SetDefaults()
		{
			item.UseSound = SoundID.Item3;
			item.useStyle = 2;
			item.useTurn = true;
			item.useAnimation = 17;
			item.useTime = 17;
			item.maxStack = 75;
			item.consumable = true;
			item.width = 14;
			item.height = 24;
			item.value = Item.buyPrice(0, 0, 2, 50);
			item.rare = 1;
		}

		public override bool CanUseItem(Player player)
		{
			if (ECPlayer.ModPlayer(player).PsychosisFull() || player.statLife <= (int)restoreAmount)
			{
				return false;
			}
			return base.CanUseItem(player);
		}

		public override bool UseItem(Player player)
		{
			ECPlayer modPlayer = player.GetModPlayer<ECPlayer>();

			float[] psychosisDiff = {modPlayer.psychosis, 0};
			if (modPlayer.psychosis < 0f)
			{
				modPlayer.psychosis = 0f;
			}
			modPlayer.PsychosisRestore(restoreAmount, false);
			psychosisDiff[1] = modPlayer.psychosis;

			if (Main.myPlayer == player.whoAmI)
			{
				//player.HealEffect((int)Math.Ceiling((psychosisDiff[1] - psychosisDiff[0])), true);
				CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), new Color(255, 105, 180, 255), (int)Math.Ceiling((psychosisDiff[1] - psychosisDiff[0])));
			}
			player.statLife -= (int)Math.Ceiling((psychosisDiff[1] - psychosisDiff[0]));
			player.lifeRegenCount = 0;
			player.lifeRegenTime = 0;

			return true;
			//return base.UseItem(player);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LesserPsychosisPotion");
			recipe.AddIngredient(ItemID.GlowingMushroom);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
