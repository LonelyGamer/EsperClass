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
	public class PsiPumpKing : ECItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Psi Pumpking Boulder");
			Tooltip.SetDefault("Does more damage the more velocity it has on impact\nLeaves a trail of Greek Fire while rolling on the ground");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 200;
			item.width = 36;
			item.height = 38;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 1;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = 8;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("Pompakin");
			onlyOne = false;
		}
	}
}
