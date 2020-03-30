using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace EsperClass.Buffs
{
	public class LessStepsAhead : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Less Steps Ahead");
			Description.SetDefault("You can't TK dodge again till this debuff is gone");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
		}
	}
}
