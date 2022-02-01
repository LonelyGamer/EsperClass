using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Items.Weapons.PreHardmode.CrossMod
{
	public class SoilSawblade : ECItem
	{
		int drainTimer = 0;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Does 1 more damage for every 666 blocks of dirt in your inventory\nUsing this weapon consumes dirt equal to 1/20th of the damage bonus on use and per second");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 1;
			item.width = 18;
			item.height = 18;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 3f;
			item.value = Item.sellPrice(0, 0, 0, 10);
			item.rare = 2;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("SoilSawblade");
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine line2 in list)
			{
			  if (line2.mod == "Terraria" && line2.Name == "ItemName")
				line2.overrideColor = new Color(151, 107, 75);
			}
			base.ModifyTooltips(list);
		}

		//Used from JoostMod Soil weapons
        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            int dirt = 0;
            for (int i = 0; i < 58; i++)
            {
                if (player.inventory[i].type == ItemID.DirtBlock && player.inventory[i].stack > 0)
                {
                    dirt += player.inventory[i].stack;
                }
            }
            flat = (dirt / 666f);
			mult *= ECPlayer.ModPlayer(player).tkDamage;
			//base.ModifyWeaponDamage(player, ref add, ref mult, ref flat);
        }

		//Also used from JoostMod Soil weapons
        public override bool CanUseItem(Player player)
        {
            int dirt = 0;
            for (int i = 0; i < 58; i++)
            {
                if (player.inventory[i].type == ItemID.DirtBlock && player.inventory[i].stack > 0)
                {
                    dirt += player.inventory[i].stack;
                }
            }
            int amount = (dirt / 666) / 20;
            for (int i = 0; i < 58 && amount > 0; i++)
            {
                if (player.inventory[i].stack > 0 && player.inventory[i].type == ItemID.DirtBlock)
                {
                    if (player.inventory[i].stack >= amount)
                    {
                        player.inventory[i].stack -= amount;
                        amount = 0;
                    }
                    else
                    {
                        amount -= player.inventory[i].stack;
                        player.inventory[i].stack = 0;
                    }
                    if (player.inventory[i].stack <= 0)
                    {
                        player.inventory[i].SetDefaults(0, false);
                    }
                    if (amount <= 0)
                    {
                        break;
                    }
                }
            }
            return base.CanUseItem(player);
        }

		public override void HoldItem(Player player)
		{
			if (player.channel)
			{
				drainTimer++;
				if (drainTimer >= 60) //if (Main.time % 60 == 0)
				{
					drainTimer -= 60;
					CanUseItem(player);
				}
			}
			else
				drainTimer = 0;
            base.HoldItem(player);
		}

		public override void AddRecipes()
		{
			Mod otherMod = ModLoader.GetMod("JoostMod");
			if (otherMod != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.DirtBlock, 666);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
