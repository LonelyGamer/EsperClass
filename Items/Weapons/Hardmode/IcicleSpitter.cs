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
	public class IcicleSpitter : ECItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Rapidly fires ice shards in the direction it is facing\nEvery second, also fires a big projectile that travels faster and deals twice as much damage");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 48;
			item.width = 26;
			item.height = 26;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 2f;
			item.value = Item.sellPrice(0, 9, 0, 0);
			item.rare = 8;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("IcicleSpitter");
		}
	}
}
