using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Items.Misc
{
	public class PsychicEye : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 8;
		}

		public override bool ItemSpace(Player player)
		{
			return true;
		}

		public override void GrabRange(Player player, ref int grabRange)
		{
			ECPlayer modPlayer = player.GetModPlayer<ECPlayer>();
			grabRange = 38 + ((modPlayer.maxPsychosis - 10) * 15);
			/*if (modPlayer.psychicEyeMagnet)
				grabRange = 300;
			else
				grabRange = Player.defaultItemGrabRange;*/
		}

		public override bool OnPickup(Player player)
		{
			ECPlayer modPlayer = player.GetModPlayer<ECPlayer>();
			modPlayer.PsychosisRestore(5f);
			Main.PlaySound(7, (int)player.position.X, (int)player.position.Y);
			return false;
		}
	}
}
