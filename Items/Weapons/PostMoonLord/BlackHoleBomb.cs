using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Weapons.PostMoonLord
{
    public class BlackHoleBomb : ECItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Black Void Engine");
			Tooltip.SetDefault("Emits a black hole, sucking in and damaging enemies/nAlso sucks in items");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 80;
			item.width = 26;
			item.height = 26;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 6f;
			item.value = Item.sellPrice(0, 20, 0, 0);
			item.rare = 10;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("BlackHoleBomb");
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
