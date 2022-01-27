using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TheConfectionRebirth.Dusts;
using Microsoft.Xna.Framework;

namespace TheConfectionRebirth.Tiles
{
public class CreamVines : ModTile
{
	public override void SetDefaults()
	{
		Main.tileCut[Type] = true;
		Main.tileBlockLight[Type] = true;
		Main.tileLavaDeath[Type] = true;
		Main.tileNoFail[Type] = true;
		Main.tileNoAttach[Type] = true;
		dustType = ModContent.DustType<CreamDust>();
		soundType = 6;
		soundStyle = 1;
	}

	public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
	{
		Tile tile = Framing.GetTileSafely(i, j + 1);
		if (tile.active() && tile.type == Type)
		{
			WorldGen.KillTile(i, j + 1);
		}
	}

	public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
	{
		Tile tileAbove = Framing.GetTileSafely(i, j - 1);
		int type = -1;
		if (tileAbove.active() && !tileAbove.bottomSlope())
		{
			type = tileAbove.type;
		}
		if (type == ModContent.TileType<CreamGrass>() || type == Type)
		{
			return true;
		}
		WorldGen.KillTile(i, j);
		return true;
	}
	
	public override void RandomUpdate(int i, int j)
	{
		Tile tileBelow = Framing.GetTileSafely(i, j + 1);
		if (!WorldGen.genRand.NextBool(15) || tileBelow.active() || tileBelow.lava())
		{
			return;
		}
		bool placeVine = false;
		int yTest = j;
		while (yTest > j - 10)
		{
			Tile testTile = Framing.GetTileSafely(i, yTest);
			if (testTile.bottomSlope())
			{
				break;
			}
			if (!testTile.active() || testTile.type != ModContent.TileType<CreamGrass>())
			{
				yTest--;
				continue;
			}
			placeVine = true;
			break;
		}
		if (placeVine)
		{
			tileBelow.type = Type;
			tileBelow.active(active: true);
			WorldGen.SquareTileFrame(i, j + 1);
			if (Main.netMode == 2)
			{
				NetMessage.SendTileSquare(-1, i, j + 1, 3);
			}
		}
	}
}
}
