using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Misc
{
	public class TaintedLotusPetal : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Permanently increases max psychosis by 1, up to 15");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 22;
			item.UseSound = SoundID.Item29;
			item.useStyle = 4;
			item.useTurn = true;
			item.useAnimation = 30;
			item.useTime = 30;
			item.maxStack = 99;
			item.consumable = true;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = 1;
		}

		public override bool CanUseItem(Player player)
		{
			return ECPlayer.ModPlayer(player).maxPsychosis < 15;
		}

		public override bool UseItem(Player player)
		{
			if (Main.myPlayer == player.whoAmI)
			{
				player.HealEffect(1, true);
			}
			ECPlayer.ModPlayer(player).maxPsychosis++;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CorruptSeeds, 2);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
