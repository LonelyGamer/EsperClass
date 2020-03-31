using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace EsperClass.Buffs
{
	public class PsychedOut : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Psyched Out");
			Description.SetDefault("You're pushing yourself to your mental limits\nYou take damage if you use telekinetic weapons\nIncreases telekinetic critical by 20%");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.blind = true;
			ECPlayer.ModPlayer(player).tkCrit += 20;
			ECPlayer.ModPlayer(player).psychosisBlock = true;
		}
	}
}
