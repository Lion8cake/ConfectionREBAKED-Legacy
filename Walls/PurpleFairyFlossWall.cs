using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TheConfectionRebirth.Dusts;

namespace TheConfectionRebirth.Walls
{
	public class  PurpleFairyFlossWall : ModWall
	{
		public override void SetDefaults() {
			Main.wallHouse[Type] = true;
			drop = ModContent.ItemType<Items.Placeable.PurpleFairyFlossWall>();
			dustType = ModContent.DustType<FairyFlossDust2>();
			AddMapEntry(new Color(105, 45, 125));
		}
		
		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
	}
}