using Microsoft.Xna.Framework;
using TheConfectionRebirth.Items.Placeable;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheConfectionRebirth.Tiles
{
public class ConfectionPainting : ModTile
{
	public override void SetDefaults()
	{
		Main.tileFrameImportant[Type] = true;
		Main.tileLavaDeath[Type] = false;
		Main.tileNoAttach[Type] = true;
		Main.tileTable[Type] = false;
		TileObjectData.newTile.Width = 3;
		TileObjectData.newTile.Height = 2;
		TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 16 };
		TileObjectData.newTile.UsesCustomCanPlace = true;
		TileObjectData.newTile.CoordinateWidth = 16;
		TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.newTile.AnchorWall = true;
		TileObjectData.addTile(Type);
		disableSmartCursor = true;
		AddMapEntry(new Color(133, 87, 50)); 
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 32, mod.ItemType("ConfectionPainting"));
		}
}
}