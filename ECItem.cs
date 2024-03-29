using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace EsperClass
{
    public abstract class ECItem : ModItem
	{
		public bool onlyOne = true;

		public override bool CloneNewInstances
		{
			get
			{
				return true;
			}
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.useStyle = 5;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			item.noUseGraphic = true;
			item.noMelee = true;
		}

		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
		{
			mult *= ECPlayer.ModPlayer(player).tkDamage;
		}

		public override void GetWeaponKnockback(Player player, ref float knockback)
		{
			knockback += ECPlayer.ModPlayer(player).tkKnockback;
		}

		public override void GetWeaponCrit(Player player, ref int crit)
		{
			crit = crit + ECPlayer.ModPlayer(player).tkCrit;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			int line = tooltips.FindLastIndex(x => x.mod == "Terraria" && x.Name == "ItemName");
			if (GetInstance<ECConfigClient>().showEsperTag && line >= 0)
			{
				TooltipLine newtip = new TooltipLine(mod, "ClassTag", "-Esper Class-");
				newtip.overrideColor = new Color(255, 105, 180);
				tooltips.Insert(line + 1, newtip);
			}
			TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
			if (tt != null)
			{
				string[] splitText = tt.text.Split(' ');
				string damageValue = splitText.First();
				string damageWord = splitText.Last();
				tt.text = damageValue + " telekinetic " + damageWord;
			}
		}

		public override int ChoosePrefix(UnifiedRandom rand)
		{
			int prefix = 0;
			if (item.maxStack > 1)
			{
				return -1;
			}
			int rando = Main.rand.Next(14);
			if (rando == 0)
			{
				prefix = 36;
			}
			if (rando == 1)
			{
				prefix = 37;
			}
			if (rando == 2)
			{
				prefix = 38;
			}
			if (rando == 3)
			{
				prefix = 53;
			}
			if (rando == 4)
			{
				prefix = 54;
			}
			if (rando == 5)
			{
				prefix = 55;
			}
			if (rando == 6)
			{
				prefix = 39;
			}
			if (rando == 7)
			{
				prefix = 40;
			}
			if (rando == 8)
			{
				prefix = 56;
			}
			if (rando == 9)
			{
				prefix = 41;
			}
			if (rando == 10)
			{
				prefix = 57;
			}
			if (rando == 11)
			{
				prefix = 59;
			}
			if (rando == 12)
			{
				prefix = 60;
			}
			if (rando == 13)
			{
				prefix = 61;
			}
			return prefix;
		}

		public override void HoldItem(Player player)
		{
			ECPlayer.ModPlayer(player).overPsychosis = false;
			if (player.channel && player.ownedProjectileCounts[item.shoot] > 0)
			{
				float amount = 1f;
				if (!onlyOne)
					amount = 3f;
				ECPlayer.ModPlayer(player).PsychosisDrain(amount);
				if (player.HasBuff(mod.BuffType("PsychedOut")))
				{
					ECPlayer.ModPlayer(player).overPsychosis = true;
				}
			}
		}

		public override bool CanUseItem(Player player)
		{
			if (onlyOne)
			{
				for (int m = 0; m < 1000; m++)
				{
					if (Main.projectile[m].active && Main.projectile[m].owner == player.whoAmI && Main.projectile[m].type == item.shoot)
						return false;
				}
			}
			return base.CanUseItem(player);
		}
	}

	public class ECItem2 : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (DetectPositives(item))
			{
				item.melee = false;
				item.ranged = false;
				item.magic = false;
				item.summon = false;
				item.thrown = false;
				item.sentry = false;
				item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/EsperUse");
			}
			base.SetDefaults(item);
		}

		public override void ModifyWeaponDamage(Item item, Player player, ref float add, ref float mult, ref float flat)
		{
			if (DetectPositives(item))
				mult *= ECPlayer.ModPlayer(player).tkDamage;
			base.ModifyWeaponDamage(item, player, ref add, ref mult, ref flat);
		}

		public override void GetWeaponKnockback(Item item, Player player, ref float knockback)
		{
			if (DetectPositives(item))
				knockback += ECPlayer.ModPlayer(player).tkKnockback;
			base.GetWeaponKnockback(item, player, ref knockback);
		}

		public override void GetWeaponCrit(Item item, Player player, ref int crit)
		{
			if (DetectPositives(item))
				crit = crit + ECPlayer.ModPlayer(player).tkCrit;
			base.GetWeaponCrit(item, player, ref crit);
		}

		public override void HoldItem(Item item, Player player)
		{
			if (DetectPositives(item))
			{
				ECPlayer.ModPlayer(player).overPsychosis = false;
				if (player.channel)
				{
					ECPlayer.ModPlayer(player).PsychosisDrain(1f);
					if (player.HasBuff(mod.BuffType("PsychedOut")))
						ECPlayer.ModPlayer(player).overPsychosis = true;
				}
			}
			base.HoldItem(item, player);
		}

		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if (DetectPositives(item))
			{
				int line = tooltips.FindLastIndex(x => x.mod == "Terraria" && x.Name == "ItemName");
				if (GetInstance<ECConfigClient>().showEsperTag && line >= 0)
				{
					TooltipLine newtip = new TooltipLine(mod, "ClassTag", "-Esper Class-");
					newtip.overrideColor = new Color(255, 105, 180);
					tooltips.Insert(line + 1, newtip);
				}
				TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
				if (tt != null)
				{
					string[] splitText = tt.text.Split(' ');
					string damageValue = splitText.First();
					string damageWord = splitText.Last();
					tt.text = damageValue + " telekinetic " + damageWord;
				}
			}
			if (item.type == ItemID.FlyingKnife)
			{
				TooltipLine newtip = new TooltipLine(mod, "Extra", "Will deal 50% extra damage if it flies in a straight line for a moment");
				tooltips.Add(newtip);
			}
			base.ModifyTooltips(item, tooltips);
		}

		public override int ChoosePrefix(Item item, UnifiedRandom rand)
		{
			if (DetectPositives(item))
			{
				int prefix = 0;
				if (item.maxStack > 1)
				{
					return -1;
				}
				int rando = Main.rand.Next(14);
				if (rando == 0)
				{
					prefix = 36;
				}
				if (rando == 1)
				{
					prefix = 37;
				}
				if (rando == 2)
				{
					prefix = 38;
				}
				if (rando == 3)
				{
					prefix = 53;
				}
				if (rando == 4)
				{
					prefix = 54;
				}
				if (rando == 5)
				{
					prefix = 55;
				}
				if (rando == 6)
				{
					prefix = 39;
				}
				if (rando == 7)
				{
					prefix = 40;
				}
				if (rando == 8)
				{
					prefix = 56;
				}
				if (rando == 9)
				{
					prefix = 41;
				}
				if (rando == 10)
				{
					prefix = 57;
				}
				if (rando == 11)
				{
					prefix = 59;
				}
				if (rando == 12)
				{
					prefix = 60;
				}
				if (rando == 13)
				{
					prefix = 61;
				}
				return prefix;
			}
			return base.ChoosePrefix(item, rand);
		}

		public bool DetectPositives(Item item)
		{
			if (item.type == ItemID.FlyingKnife)
				return true;

			List<int> TKItem = EsperClass.TKItem;
			foreach (var IsTKItem in EsperClass.TKItem)
			{
				if (item.type == IsTKItem)
					return true;
			}
			return false;
		}
	}

	public abstract class ECTagItem : ModItem
	{
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			int line = tooltips.FindLastIndex(x => x.mod == "Terraria" && x.Name == "ItemName");
			if (GetInstance<ECConfigClient>().showEsperTag && line >= 0)
			{
				TooltipLine newtip = new TooltipLine(mod, "ClassTag", "-Esper Class-");
				newtip.overrideColor = new Color(255, 105, 180);
				tooltips.Insert(line + 1, newtip);
			}
		}
	}
}
