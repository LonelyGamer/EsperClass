using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Weapons.Hardmode
{
    public class SharknadoRift : ECItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Slowly fires Sharknados toward the nearest enemy\nSharknados explode into a water tornado on impact");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 80;
			item.width = 36;
			item.height = 34;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6f;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 24f;
			item.shoot = mod.ProjectileType("SharknadoRift");
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("imkSushisMod");
			if (otherMod != null)
			{
				//From
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.Flairon);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.Tsunami);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.RazorbladeTyphoon);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.BubbleGun);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.TempestStaff);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();

				/*recipe = new ModRecipe(mod);
				recipe.AddIngredient(mod, "BubbleTurret");
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(this);
				recipe.AddRecipe();*/

				//To
				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.Flairon);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.Tsunami);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.RazorbladeTyphoon);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.BubbleGun);
				recipe.AddRecipe();

				recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(ItemID.TempestStaff);
				recipe.AddRecipe();

				/*recipe = new ModRecipe(mod);
				recipe.AddIngredient(this);
				recipe.AddIngredient(otherMod, "SwapToken");
				recipe.AddTile(TileID.TinkerersWorkbench);
				recipe.SetResult(mod, "BubbleTurret");
				recipe.AddRecipe();*/
			}
			otherMod = ModLoader.GetMod("BossLootPlus");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(otherMod, "FishronScale", 5);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
