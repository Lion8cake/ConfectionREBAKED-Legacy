using TheConfectionRebirth.Dusts;
using TheConfectionRebirth.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Tiles
{
    public class PastryBlock : ModTile
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
            Main.tileLighted[Type] = false;
            drop = ModContent.ItemType<Items.Placeable.PastryBlock>();
            AddMapEntry(new Color(84, 28, 187));
			dustType = mod.DustType("PastryDust");
        }
    }
}