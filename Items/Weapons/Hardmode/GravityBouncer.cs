using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Weapons.Hardmode
{
    public class GravityBouncer : ECItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gravity Crasher");
			Tooltip.SetDefault("Every 3rd bounce explodes");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 300;
			item.width = 30;
			item.height = 30;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = 10;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 24f;
			item.shoot = mod.ProjectileType("GravityBouncer");
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
