using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Weapons.PostMoonLord
{
    public class AccretionDisc : ECItem
	{
		public override void SetStaticDefaults()
		{
            Tooltip.SetDefault("Surrounded by an aura that grows in size (up to a limit) dealing damage\nCauses shorter target immune frames on hit");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 180;
			item.width = 32;
			item.height = 32;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 5f;
			item.value = Item.sellPrice(0, 20, 0, 0);
			item.rare = 10;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 24f;
			item.shoot = mod.ProjectileType("AccretionDisc");
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("BossLootPlus");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(otherMod, "LunarEssence", 5);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
