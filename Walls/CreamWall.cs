using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TheConfectionRebirth.Dusts;

namespace TheConfectionRebirth.Walls
{
	public class CreamWall : ModWall
	{
		public override void SetDefaults() {
			Main.wallHouse[Type] = false;
			dustType = ModContent.DustType<CreamSnowDust>();
			AddMapEntry(new Color(74, 61, 43));
		}
		
		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
	}
}