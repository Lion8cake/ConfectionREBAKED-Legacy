using Microsoft.Xna.Framework;
using TheConfectionRebirth.Items.Placeable;
using TheConfectionRebirth.Dusts;
using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Walls
{
	public class BlueFairyFlossWall : ModWall
	{
		public override void SetDefaults() {
			Main.wallHouse[Type] = true;
			dustType = ModContent.DustType<FairyFlossDust3>();
			drop = ModContent.ItemType<Items.Placeable.BlueFairyFlossWall>();
			AddMapEntry(new Color(39, 95, 126));
		}
		
		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
	}
}
