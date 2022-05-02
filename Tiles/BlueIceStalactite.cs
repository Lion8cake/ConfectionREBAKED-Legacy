using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TheConfectionRebirth.Dusts;
using Microsoft.Xna.Framework;

namespace TheConfectionRebirth.Tiles
{
	public class BlueIceStalactite : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = false;
			dustType = ModContent.DustType<CreamDust>();
			disableSmartCursor = true;
		}
	
		public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
		{
			Tile tile = Main.tile[i, j];
			if (tile.frameY <= 18 || tile.frameY == 72)
			{
				offsetY = -2;
			}
			else if ((tile.frameY >= 36 && tile.frameY <= 54) || tile.frameY == 90)
			{
				offsetY = 2;
			}
		}
	
		public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
		{
			WorldGen.CheckTight(i, j);
			return false;
		}
	
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 4);
		}
	}
}