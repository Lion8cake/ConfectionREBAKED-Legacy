using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Tiles
{
	public class Creamstone : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileMerge[Type][mod.TileType("CookieBlock")] = true;
			Main.tileMerge[Type][mod.TileType("CreamGrass")] = true;
			Main.tileMerge[Type][mod.TileType("HallowedOre")] = true;
			Main.tileMerge[Type][mod.TileType("NeapoliniteOre")] = true;
			Main.tileMerge[Type][mod.TileType("CreamstoneBrick")] = true;
			Main.tileMerge[Type][mod.TileType("SacchariteBlock")] = true;
			Main.tileMerge[Type][mod.TileType("CreamWood")] = true;
			Main.tileMerge[Type][mod.TileType("CreamBlock")] = true;
			Main.tileMerge[Type][mod.TileType("BlueIce")] = true;
			Main.tileMerge[Type][mod.TileType("CreamstoneRuby")] = true;
			Main.tileMerge[Type][mod.TileType("CreamstoneSaphire")] = true;
			Main.tileMerge[Type][mod.TileType("CreamstoneDiamond")] = true;
			Main.tileMerge[Type][mod.TileType("CreamstoneAmethyst")] = true;
			Main.tileMerge[Type][mod.TileType("CreamstoneTopaz")] = true;
			Main.tileMerge[Type][mod.TileType("CreamstoneEmerald")] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			dustType = mod.DustType("CreamDust");
			drop = ModContent.ItemType<Items.Placeable.Creamstone>();
			AddMapEntry(new Color(188, 168, 120));
			
			soundType = SoundID.Tink;
			soundStyle = 1;
			minPick = 65;
		}
	
	public override void RandomUpdate(int i, int j)
	{
          ConfectionWorld.InfectionSpread(i, j, "Confection");
	
	    Tile tile = Framing.GetTileSafely(i, j);
	    	Tile tileBelow = Framing.GetTileSafely(i, j + 1);
    		Tile tileAbove = Framing.GetTileSafely(i, j - 1);
	    	if (WorldGen.genRand.NextBool(45) && !tileBelow.active() && !tileBelow.lava() && !tile.bottomSlope())
    		{
    			tileBelow.type = (ushort)ModContent.TileType<SacchariteBlock>();
    			tileBelow.active(active: true);
	    		WorldGen.SquareTileFrame(i, j + 1);
    			if (Main.netMode == 2)
	    		{
				NetMessage.SendTileSquare(-1, i, j + 1, 3);
	    		}
	    	}
			if (WorldGen.genRand.NextBool(45) && !tileBelow.active() && !tileBelow.lava() && !tile.bottomSlope())
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

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
	}
}