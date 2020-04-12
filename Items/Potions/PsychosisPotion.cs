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
		public float restoreAmount = 20f;

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Restores 20 psychosis");
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
			if (player.FindBuffIndex(mod.BuffType("SideEffects")) > -1
			|| ECPlayer.ModPlayer(player).PsychosisFull())
			{
				return false;
			}
			return base.CanUseItem(player);
		}

		public override bool UseItem(Player player)
		{
			ECPlayer modPlayer = player.GetModPlayer<ECPlayer>();

			player.AddBuff(mod.BuffType("SideEffects"), 300);
			float[] psychosisDiff = {modPlayer.psychosis, 0};
			if (modPlayer.psychosis < 0f)
			{
				modPlayer.psychosis = 0f;
			}
			modPlayer.PsychosisRestore(restoreAmount, false);
			psychosisDiff[1] = modPlayer.psychosis;

			if (Main.myPlayer == player.whoAmI)
			{
				player.HealEffect((int)Math.Ceiling((psychosisDiff[1] - psychosisDiff[0])), true);
			}

			return true;
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
