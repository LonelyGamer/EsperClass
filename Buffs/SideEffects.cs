using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace EsperClass.Buffs
{
	public class SideEffects : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Side Effects");
			Description.SetDefault("You deal 20% less TK damage and can't regen psychosis");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			ECPlayer.ModPlayer(player).tkDamage -= 0.2f;
			ECPlayer.ModPlayer(player).psychosisBlock = true;
		}
	}
}
