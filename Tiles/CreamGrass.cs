using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Tiles
{
    public class CreamGrass : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            this.SetModTree(new Trees.CreamTree());
            Main.tileMerge[Type][mod.TileType("CreamGrass")] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBrick[Type] = true;
		    Main.tileSolid[Type] = true;
		    Main.tileBlockLight[Type] = true;
		    TileID.Sets.Grass[Type] = true;
		    TileID.Sets.ChecksForMerge[Type] = true;
            AddMapEntry(new Color(235, 207, 150));
            soundType = 0;
            soundStyle = 2;
            drop = mod.ItemType("CookieBlock");
        }
		
        public static bool PlaceObject(int x, int y, int type, bool mute = false, int style = 0, int alternate = 0, int random = -1, int direction = -1)
        {
            TileObject objectData;
            if (!TileObject.CanPlace(x, y, type, style, direction, out objectData, false, false))
                return false;
            objectData.random = random;
            if (TileObject.Place(objectData) && !mute)
                WorldGen.SquareTileFrame(x, y, true);
            return false;
        }
		
        public override void RandomUpdate(int i, int j)
        {
			ConfectionWorld.InfectionSpread(i, j, "Confection");
		    
	   	    Tile tile = Framing.GetTileSafely(i, j);
	    	Tile tileBelow = Framing.GetTileSafely(i, j + 1);
    		Tile tileAbove = Framing.GetTileSafely(i, j - 1);
	    	if (WorldGen.genRand.NextBool(15) && !tileBelow.active() && !tileBelow.lava() && !tile.bottomSlope())
    		{
    			tileBelow.type = (ushort)ModContent.TileType<CreamVines>();
    			tileBelow.active(active: true);
	    		WorldGen.SquareTileFrame(i, j + 1);
    			if (Main.netMode == 2)
	    		{
				NetMessage.SendTileSquare(-1, i, j + 1, 3);
	    		}
	    	}
	  	
            if (Framing.GetTileSafely(i, j - 1).active())
                return;
            switch (Main.rand.Next(14))
            {
                case 0:
                    PlaceObject(i, j - 1, this.mod.TileType("CreamGrass1"), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacment(-1, i, j - 1, this.mod.TileType("CreamGrass1"), 0, 0, -1, -1);
                    break;
                case 1:
                    PlaceObject(i, j - 1, this.mod.TileType("CreamGrass2"), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacment(-1, i, j - 1, this.mod.TileType("CreamGrass2"), 0, 0, -1, -1);
                    break;
                case 2:
                    PlaceObject(i, j - 1, this.mod.TileType("CreamGrass3"), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacment(-1, i, j - 1, this.mod.TileType("CreamGrass3"), 0, 0, -1, -1);
                    break;
                case 3:
                    PlaceObject(i, j - 1, this.mod.TileType("CreamGrass4"), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacment(-1, i, j - 1, this.mod.TileType("CreamGrass4"), 0, 0, -1, -1);
                    break;
				case 4:
                    PlaceObject(i, j - 1, this.mod.TileType("CreamGrass5"), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacment(-1, i, j - 1, this.mod.TileType("CreamGrass5"), 0, 0, -1, -1);
                    break;
				case 5:
                    PlaceObject(i, j - 1, this.mod.TileType("CreamGrass6"), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacment(-1, i, j - 1, this.mod.TileType("CreamGrass6"), 0, 0, -1, -1);
                    break;
				case 6:
                    PlaceObject(i, j - 1, this.mod.TileType("CreamGrass7"), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacment(-1, i, j - 1, this.mod.TileType("CreamGrass7"), 0, 0, -1, -1);
                    break;
				case 7:
                    PlaceObject(i, j - 1, this.mod.TileType("CreamGrass8"), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacment(-1, i, j - 1, this.mod.TileType("CreamGrass8"), 0, 0, -1, -1);
                    break;
				case 8:
                    PlaceObject(i, j - 1, this.mod.TileType("CreamGrass9"), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacment(-1, i, j - 1, this.mod.TileType("CreamGrass9"), 0, 0, -1, -1);
                    break;
				case 9:
                    PlaceObject(i, j - 1, this.mod.TileType("CreamGrass10"), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacment(-1, i, j - 1, this.mod.TileType("CreamGrass10"), 0, 0, -1, -1);
                    break;
				case 10:
                    PlaceObject(i, j - 1, this.mod.TileType("CreamGrass11"), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacment(-1, i, j - 1, this.mod.TileType("CreamGrass11"), 0, 0, -1, -1);
                    break;
				case 11:
                    PlaceObject(i, j - 1, this.mod.TileType("CreamGrass12"), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacment(-1, i, j - 1, this.mod.TileType("CreamGrass12"), 0, 0, -1, -1);
                    break;
                default:
                    PlaceObject(i, j - 1, this.mod.TileType("YumDrop"), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacment(-1, i, j - 1, this.mod.TileType("YumDrop"), 0, 0, -1, -1);
                    break;
            }
        }
		
		public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
		{
			if (fail && !effectOnly)
			{
				Main.tile[i, j].type = (ushort)ModContent.TileType<CookieBlock>();
			}
		}
		
        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return mod.TileType("CreamSapling"); 
        }
    }
}