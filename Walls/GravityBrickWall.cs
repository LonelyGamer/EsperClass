using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Walls
{
	public class GravityBrickWall : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			dustType = 162;
			drop = ItemType<Items.Placeables.GravityBrickWall>();
			AddMapEntry(new Color(255, 206, 49));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}