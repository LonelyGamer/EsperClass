using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Items.Misc
{
	public class SolarLotusPetal : ECTagItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Permanently increases max psychosis by 1, up to 30\nRequires at least 25 max psychosis");
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
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 8;
		}

		public override bool CanUseItem(Player player)
		{
			return ECPlayer.ModPlayer(player).maxPsychosis < 30 && ECPlayer.ModPlayer(player).maxPsychosis >= 25;
		}

		public override bool UseItem(Player player)
		{
			if (Main.myPlayer == player.whoAmI)
				CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), new Color(255, 105, 180, 255), 1);
			ECPlayer.ModPlayer(player).maxPsychosis++;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 3);
			recipe.AddIngredient(ItemID.Nanites, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
