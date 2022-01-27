using TheConfectionRebirth.Dusts;
using TheConfectionRebirth.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Tiles
{
    public class ShellBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][mod.TileType("CreamGrass")] = true;
            Main.tileMerge[Type][mod.TileType("Creamstone")] = true;
            Main.tileMerge[Type][mod.TileType("CreamWood")] = true;
			Main.tileMerge[Type][mod.TileType("CookieBlock")] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = ModContent.ItemType<Items.Placeable.ShellBlock>();
            AddMapEntry(new Color(84, 28, 187));
			dustType = mod.DustType("ShellBlockDust");
        }
		
    		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    	{
      		r = 1.98f;
    		g = 0.5f;
    		b = 1.4f;
    	}
    }
}