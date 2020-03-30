using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.PreHardmode
{
	public class PinkSlimyCanister : ECItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Pours down damaging pink slimy liquid");
		}

		public override void SetDefaults()
		{
      item.channel = true;
			item.maxStack = 1;
			item.damage = 12;
			item.width = 16;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 0;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 1;
      item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("PinkSlimyCanister");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SlimyCanister");
			recipe.AddIngredient(ItemID.PinkGel, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
