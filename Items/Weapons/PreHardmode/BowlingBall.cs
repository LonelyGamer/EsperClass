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
	public class BowlingBall : ECItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Acts like TK Boulders, but recoverable\nBest used with cousins");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 999;
			item.consumable = true;
			item.damage = 40;
			item.width = 26;
			item.height = 26;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 1;
			item.knockBack = 5f;
			item.value = Item.sellPrice(0, 0, 2, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 10f;
			item.shoot = mod.ProjectileType("BowlingBall");
			onlyOne = false;
		}
	}
}
