using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EsperClass.Buffs.CrossMod
{
	public class TelekineticImmulation : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Telekinetic Immulation");
			Description.SetDefault("Increases telekinetic damage by 50%"
				+ "\nIncreases telekinetic velocity by 50%"
				+ "\nDouble tap " + Language.GetTextValue(Main.ReversedUpDownArmorSetBonuses ? "Key.UP" : "Key.DOWN") + " to summon a gravity field");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			ECPlayer.ModPlayer(player).gravityPotion = true;
		}
	}
}
