using Terraria;
using Terraria.ModLoader;

namespace EsperClass.Buffs
{
    public class Irradiated : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Irradiated");
			Description.SetDefault("You normally wouldn't see this");
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<ECNPC>().irradiated = true;
			npc.onFire = true;
			npc.poisoned = true;
			if (npc.lifeRegen > 0)
			{
				npc.lifeRegen = 0;
			}
			npc.lifeRegen -= 100;
		}
	}
}
