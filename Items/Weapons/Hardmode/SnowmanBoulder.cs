using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.Hardmode
{
	public class SnowmanBoulder : ECItem
	{
		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 999;
			item.consumable = true;
			item.damage = 120;
			item.width = 38;
			item.height = 30;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 1;
			item.knockBack = 6f;
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("SnowmanBoulder");
			onlyOne = false;
		}
	}
}
