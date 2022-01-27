using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Tiles
{
	public class BlueIce : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMerge[Type][mod.TileType("CookieBlock")] = true;
			Main.tileMerge[Type][mod.TileType("CreamGrass")] = true;
			Main.tileMerge[Type][mod.TileType("HallowedOre")] = true;
			Main.tileMerge[Type][mod.TileType("NeapoliniteOre")] = true;
			Main.tileMerge[Type][mod.TileType("CreamstoneBrick")] = true;
			Main.tileMerge[Type][mod.TileType("CreamWood")] = true;
			Main.tileMerge[Type][mod.TileType("CreamBlock")] = true;
            Main.tileMerge[Type][161] = true;
            Main.tileMerge[Type][163] = true;
            Main.tileMerge[Type][164] = true;
            Main.tileMerge[Type][200] = true;
            Main.tileMerge[Type][147] = true;
            Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			TileID.Sets.Ices[Type] = true;
		    TileID.Sets.IcesSlush[Type] = true;
		    TileID.Sets.IcesSnow[Type] = true;
			TileID.Sets.Conversion.Ice[Type] = true;
			dustType = mod.DustType("OrangeIceDust");
			drop = ModContent.ItemType<Items.Placeable.OrangeIce>();
			AddMapEntry(new Color(237, 145, 103));
			
			soundType = SoundID.Tink;
			soundStyle = 2;
		}
		
		public override void FloorVisuals(Player player)
	    {
		    player.slippy = true;
	    }

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
		
		public override void RandomUpdate(int i, int j)
        {
          ConfectionWorld.InfectionSpread(i, j, "Confection");
        }
	}
}