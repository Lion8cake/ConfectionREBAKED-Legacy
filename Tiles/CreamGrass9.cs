using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheConfectionRebirth.Tiles
{
    public class CreamGrass9 : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.addTile(Type);
            Main.tileCut[Type] = true;
            Main.tileNoFail[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = false;
			dustType = mod.DustType("CreamDust");
            mineResist = 1f;
            TileObjectData.newTile.CoordinateHeights = new int[]
          {
        18
          };
            TileObjectData.addTile(Type);         
            this.soundType = 6;
        }
		
		public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
	{
		Tile tileBelow = Framing.GetTileSafely(i, j + 1);
		int type = -1;
		if (tileBelow.active() && !tileBelow.bottomSlope())
		{
			type = tileBelow.type;
		}
		if (type == ModContent.TileType<CreamGrass>() || type == Type)
		{
			return true;
		}
		WorldGen.KillTile(i, j);
		return true;
	}
    }
}
