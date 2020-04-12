using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Misc
{
	public class AncientLotusPetal : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Permanently increases max psychosis by 1, up to 20\nRequires at least 15 max psychosis");
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
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = 3;
		}

		public override bool CanUseItem(Player player)
		{
			return ECPlayer.ModPlayer(player).maxPsychosis < 20 && ECPlayer.ModPlayer(player).maxPsychosis >= 15;
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
			recipe.AddIngredient(ItemID.Bone, 10);
			recipe.AddIngredient(ItemID.WaterCandle);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
