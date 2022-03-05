using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.PostMoonLord
{
	public class EldritchEyeJar : ECItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Spawns eldritch eyes that will hunt down enemies\nRequires shaking up and down to function\nWill last for 8 seconds before needing more shaking");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 240;
			item.width = 20;
			item.height = 26;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 2f;
			item.value = Item.sellPrice(0, 20, 0, 0);
			item.rare = 10;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("EldritchEyeJar");
		}
	}
}
