using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EsperClass.Tiles
{
	public class GravityBrick : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			//Main.tileLighted[Type] = true;
			dustType = 162;
			drop = ItemType<Items.Placeables.GravityBrick>();
			AddMapEntry(new Color(255, 206, 49));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}