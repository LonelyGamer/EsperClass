using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Weapons.Hardmode
{
    public class BetsyPsi : ECItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Betsy Scorcher");
			Tooltip.SetDefault("Blows down fire");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 50;
			item.width = 46;
			item.height = 38;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2f;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = 8;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 20f;
			item.shoot = mod.ProjectileType("BetsyHead");
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("imkSushisMod");
			if (otherMod != null)
			{
				//From
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.DD2SquireBetsySword);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.MonkStaffT3);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.DD2BetsyBow);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.ApprenticeStaffT3);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				//To
				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.DD2SquireBetsySword);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.MonkStaffT3);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.DD2BetsyBow);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.ApprenticeStaffT3);
				recipe.AddRecipe();
			}
			otherMod = ModLoader.GetMod("BossLootPlus");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(otherMod, "EtheriaFlame", 5);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
