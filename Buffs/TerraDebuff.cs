using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace EsperClass.Buffs
{
	public class TerraDebuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Terra Debuff");
			Description.SetDefault("You normally wouldn't see this");
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.onFire = true;
			npc.onFrostBurn = true;
			npc.poisoned = true;
			npc.onFire2 = true;
			npc.ichor = true;
			npc.midas = true;
			npc.shadowFlame = true;
			npc.venom = true;
		}
	}
}
