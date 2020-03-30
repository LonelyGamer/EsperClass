using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace EsperClass.Buffs
{
	public class Willful : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Willful");
			Description.SetDefault("Increases telekinesis damage by 20%");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			ECPlayer.ModPlayer(player).willfulPotion = true;
		}
	}
}
