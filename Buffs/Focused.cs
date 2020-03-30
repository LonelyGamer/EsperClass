using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace EsperClass.Buffs
{
	public class Focused : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Focused");
			Description.SetDefault("Increases telekinesis critical by 12%");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			ECPlayer.ModPlayer(player).focusedPotion = true;
		}
	}
}
