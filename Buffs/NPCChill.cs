using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace EsperClass.Buffs
{
	public class NPCChill : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("NPC Chill");
			Description.SetDefault("You normally wouldn't see this");
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			if (!npc.boss && !(npc.type >= 551 && npc.type <= 578))
			{
				npc.velocity.X = 0;
				npc.velocity.Y = 0;
			}
		}
	}
}
