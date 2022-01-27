using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
 
namespace TheConfectionRebirth.Tiles          
{
    public class ConfectionCrate : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = true;     
            Main.tileFrameImportant[Type] = true;
            Main.tileTable[Type] = true;     
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            AddMapEntry(new Color(133, 87, 50)); 
            TileObjectData.addTile(Type);
 
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("ConfectionCrate"));
        }
    }
}