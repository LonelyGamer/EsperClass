using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace EsperClass.Buffs
{
	public class Alert : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Alert");
			Description.SetDefault("Increases telekinetic velocity by 30%");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			ECPlayer.ModPlayer(player).alertPotion = true;
		}
	}
}
