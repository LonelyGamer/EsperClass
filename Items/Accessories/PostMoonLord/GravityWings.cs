using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Accessories.PostMoonLord
{
	[AutoloadEquip(EquipType.Wings)]
	public class GravityWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gravity Barrier Platform");
			Tooltip.SetDefault("Allows flight and slow fall\nHold DOWN and JUMP to hover\nUses psychosis to stay afloat upon running out of flight time");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 22;
			item.accessory = true;
			item.rare = 10;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.noUseGraphic = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 180;
			player.wingsLogic = 22;
		}

        public override bool WingUpdate(Player player, bool inUse)
        {
			if (inUse)
			{
				if (player.wingTime < 4 && !player.HasBuff(mod.BuffType("PsychedOut")))
				{
					ECPlayer.ModPlayer(player).PsychosisDrain(3f);
					player.wingTime++;
				}
			}
			player.wingFrameCounter++;
			if (player.wingFrameCounter > 3)
			{
				player.wingFrameCounter = 0;
				player.wingFrame++;
				if (player.wingFrame > 3)
				{
					player.wingFrame = 0;
				}
			}
			//if ((drawPlayer.velocity.Y != 0f || drawPlayer.grappling[0] != -1) && !drawPlayer.mount.Active)
            return true;
        }

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 9f;
			acceleration *= 2.5f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(null, "GravityFragment", 14);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
