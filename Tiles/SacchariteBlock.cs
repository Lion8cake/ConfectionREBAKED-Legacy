using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;

namespace TheConfectionRebirth.Tiles
{
	public class SacchariteBlock : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = false;
		    Main.tileLighted[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileMerge[Type][mod.TileType("Creamstone")] = true;
			drop = ModContent.ItemType<Items.Placeable.Saccharite>();
			AddMapEntry(new Color(32, 174, 221));
			dustType = mod.DustType("SacchariteCrystals");
		}
		
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    	{
      		r = 0.00f;
    		g = 0.01f;
    		b = 0.02f;
			float bonusStrength = 3.5f;
    		float strength = 0f + (float)Math.Sin(MathHelper.ToRadians((float)(Main.time / 6.0))) * bonusStrength;
    		Lighting.AddLight(new Vector2((float)(i * 16) + 8f, (float)(j * 16) + 8f), r * strength, g * strength, b * strength);
    	}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
	
	public override void RandomUpdate(int i, int j)
	{
		Tile tile = Framing.GetTileSafely(i, j);
	    	Tile tileBelow = Framing.GetTileSafely(i, j + 1);
    		Tile tileAbove = Framing.GetTileSafely(i, j - 1);
	    	if (WorldGen.genRand.NextBool(30) && !tileBelow.active() && !tileBelow.lava() && !tile.bottomSlope())
    		{
    			tileBelow.type = (ushort)ModContent.TileType<SacchariteBlock>();
    			tileBelow.active(active: true);
	    		WorldGen.SquareTileFrame(i, j + 1);
    			if (Main.netMode == 2)
	    		{
				NetMessage.SendTileSquare(-1, i, j + 1, 3);
	    		}
	    	}
			if (WorldGen.genRand.NextBool(30) && !tileBelow.active() && !tileBelow.lava() && !tile.bottomSlope())
    		{
    			tileBelow.type = (ushort)ModContent.TileType<SacchariteBlock>();
    			tileBelow.active(active: true);
	    		WorldGen.SquareTileFrame(i, j - 1);
    			if (Main.netMode == 2)
	    		{
				NetMessage.SendTileSquare(-1, i, j - 1, 3);
	    		}
	    	}
	    }
	}
}