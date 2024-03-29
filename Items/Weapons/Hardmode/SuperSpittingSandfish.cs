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
	public class SuperSpittingSandfish : ECItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Fires three bubbles in the direction it is facing");
		}

		public override void UpdateInventory(Player player)
		{
			ECPlayer.ModPlayer(player).caughtSandfish2 = true;
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 36;
			item.width = 24;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 2f;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.rare = 5;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("SuperSpittingSandfish");
		}
	}
}
