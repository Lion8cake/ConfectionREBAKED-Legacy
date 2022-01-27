using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Tiles
{
	public class CreamWood : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			Main.tileMerge[Type][mod.TileType("Creamstone")] = true;
			Main.tileMerge[Type][mod.TileType("CreamstoneBrick")] = true;
			Main.tileMerge[Type][mod.TileType("CookieBlock")] = true;
			Main.tileMerge[Type][mod.TileType("CreamGrass")] = true;
			drop = ModContent.ItemType<Items.Placeable.CreamWood>();
			AddMapEntry(new Color(153, 97, 60));
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
	}
}