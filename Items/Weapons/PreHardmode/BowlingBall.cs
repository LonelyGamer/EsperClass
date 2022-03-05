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
			Tooltip.SetDefault("Best used with cousins");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 60;
			item.width = 26;
			item.height = 26;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 1;
			item.knockBack = 5f;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = 2;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 10f;
			item.shoot = mod.ProjectileType("BowlingBall");
			onlyOne = false;
		}

		public override void UpdateInventory(Player player)
		{
			if (item.stack > 1)
				item.stack = 1;
		}
	}
}
