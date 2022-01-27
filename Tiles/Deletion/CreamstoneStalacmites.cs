using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

//If your confused let me just say that Creamstone stalactites got an overhaul and this code is here to delete all the old pregenerated creamstone stalacmites before this update.

namespace TheConfectionRebirth.Tiles.Deletion
{
public class CreamstoneStalacmites : ModTile
{
	public override void SetDefaults()
	{
		Main.tileSolidTop[Type] = false;
		Main.tileFrameImportant[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileTable[Type] = true;
		Main.tileLavaDeath[Type] = false;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
		TileObjectData.addTile(Type);
		disableSmartCursor = true;
	}

	public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
	{
		if (i % 4 < 3)
		{
			spriteEffects = (SpriteEffects)1;
		}
	}

	public override void NumDust(int i, int j, bool fail, ref int num)
	{
		num = (fail ? 1 : 3);
	}

	public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
	{
		frameXOffset = i % 3 * 18;
	}

	public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
	{
		offsetY = -4;
	}
	
	//deletion code
	public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
	{
		Tile tileBelow = Framing.GetTileSafely(i, j + 1);
		WorldGen.KillTile(i, j);
		return true;
	}
}
}