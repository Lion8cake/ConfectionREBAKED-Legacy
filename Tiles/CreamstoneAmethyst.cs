using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Tiles
{
	public class CreamstoneAmethyst : ModTile
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
			Main.tileMerge[Type][mod.TileType("Creamstone")] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			drop = ItemID.Amethyst;
			dustType = mod.DustType("CreamDust");
			AddMapEntry(new Color(188, 168, 120));
			
			soundType = SoundID.Tink;
			soundStyle = 1;
			minPick = 65;
		}
		
	
	public override void RandomUpdate(int i, int j)
	{
	     ConfectionWorld.InfectionSpread(i, j, "Confection");
	}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
	}
}