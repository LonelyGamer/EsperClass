using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Weapons.Hardmode
{
    public class GravityTwirler : ECItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Binary Rays");
			Tooltip.SetDefault("Spins around two lasers\nTriggers longer hit immunity frames on targets");
		}

		/*public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			int line = tooltips.FindLastIndex(x => x.mod == "Terraria" && x.Name == "Tooltip0");
			if (line >= 0)
			{
				TooltipLine newtip = new TooltipLine(mod, "Warning", "Cannot (by design) hit targets that are too close to the center of the weapon");
				newtip.overrideColor = new Color(255, 0, 0);
				tooltips.Insert(line + 1, newtip);
			}
			base.ModifyTooltips(tooltips);
		}*/

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 600;
			item.width = 26;
			item.height = 38;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 2f;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = 10;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("GravityTwirler");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GravityFragment", 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
