using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EsperClass.Tiles
{
	public class GravityFragmentBlock : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileMerge[Type][TileID.LunarBlockSolar] = true;
			Main.tileMerge[Type][TileID.LunarBlockVortex] = true;
			Main.tileMerge[Type][TileID.LunarBlockNebula] = true;
			Main.tileMerge[Type][TileID.LunarBlockStardust] = true;
			//Main.tileMerge[Type][mod.ItemType("GravityBrick")] = true;
			Main.tileMerge[TileID.LunarBlockSolar][Type] = true;
			Main.tileMerge[TileID.LunarBlockVortex][Type] = true;
			Main.tileMerge[TileID.LunarBlockNebula][Type] = true;
			Main.tileMerge[TileID.LunarBlockStardust][Type] = true;
			//Main.tileMerge[mod.ItemType("GravityBrick")][Type] = true;
			Main.tileLighted[Type] = true;
			dustType = 162;
			drop = mod.ItemType("GravityFragmentBlock");
			AddMapEntry(new Color(255, 206, 49));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 1f;
			g = 0.808f;
			b = 0.192f;
		}
	}
}
