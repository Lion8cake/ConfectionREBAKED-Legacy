using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Tiles
{
	public class CreamstoneBrick : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileMerge[Type][mod.TileType("CookieBlock")] = true;
			Main.tileMerge[Type][mod.TileType("CreamGrass")] = true;
			Main.tileMerge[Type][mod.TileType("CreamWood")] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			dustType = mod.DustType("CreamDust");
			drop = ModContent.ItemType<Items.Placeable.CreamstoneBrick>();
			AddMapEntry(new Color(180, 156, 103));
			
			soundType = SoundID.Tink;
			soundStyle = 1;
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
	}
}