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
	public class DeadDoll : ECItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Pours down damaging hairs\nRequires shaking up and down to function\nWill last for 8 seconds before needing more shaking");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 40;
			item.width = 26;
			item.height = 48;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 1f;
			item.value = Item.sellPrice(0, 4, 60, 0);
			item.rare = 5;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("DeadDoll");
		}

		/*public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("imkSushisMod");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(otherMod, "LootPlanteraToken", 25);
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}*/
	}
}
