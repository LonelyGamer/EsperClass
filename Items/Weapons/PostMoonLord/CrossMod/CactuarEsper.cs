using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Weapons.PostMoonLord.CrossMod
{
    public class CactuarEsper : ECItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mini Cactuar");
			Tooltip.SetDefault("Spreads out 60 needles per second, in a random direction");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			int line = tooltips.FindLastIndex(x => x.mod == "Terraria" && x.Name == "Tooltip0");
			if (line >= 0)
			{
				TooltipLine newtip = new TooltipLine(mod, "Warning", "By design, needles deal 1/3 damage (before defense) on the first 3 frames of being spawned");
				newtip.overrideColor = new Color(255, 0, 0);
				tooltips.Insert(line + 1, newtip);
			}
			base.ModifyTooltips(tooltips);
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 120;
			item.width = 32;
			item.height = 32;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 25, 0, 0);
			item.rare = 11;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 24f;
			item.shoot = mod.ProjectileType("MiniCactuar");
		}

		public override void AddRecipes()
		{
			Mod JoostMod = ModLoader.GetMod("JoostMod");
			if (JoostMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(JoostMod, "Cactustoken");
				recipe.SetResult(this);
				recipe.AddRecipe();
			}			
		}
	}
}
