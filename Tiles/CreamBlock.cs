using TheConfectionRebirth.Dusts;
using TheConfectionRebirth.Items.Placeable;
using TheConfectionRebirth.Tiles.Trees;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Tiles
{
    public class CreamBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][mod.TileType("CreamGrass")] = true;
            Main.tileMerge[Type][mod.TileType("Creamstone")] = true;
            Main.tileMerge[Type][mod.TileType("CreamWood")] = true;
 			Main.tileMerge[Type][mod.TileType("BlueIce")] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = false;
			TileID.Sets.Snow[Type] = true;
			dustType = mod.DustType("CreamSnowDust");
            drop = ModContent.ItemType<Items.Placeable.CreamBlock>();
            AddMapEntry(new Color(219, 223, 234));
			this.SetModTree(new Trees.CreamSnowTree());
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = (fail ? 1 : 3);
        }

	    public override int SaplingGrowthType(ref int style)
	    {
		    style = 0;
		    return ModContent.TileType<CreamSnowSapling>();
	    }
		
		public override void RandomUpdate(int i, int j)
        {
          ConfectionWorld.InfectionSpread(i, j, "Confection");
        }
    }
}