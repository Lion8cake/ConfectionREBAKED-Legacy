using Microsoft.Xna.Framework;
using TheConfectionRebirth.Items.Placeable;
using TheConfectionRebirth.Dusts;
using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Walls
{
	public class CreamstoneBrickWall : ModWall
	{
		public override void SetDefaults() {
			Main.wallHouse[Type] = true;
			dustType = ModContent.DustType<CreamDust>();
			drop = ModContent.ItemType<Items.Placeable.CreamstoneBrickWall>();
			AddMapEntry(new Color(74, 61, 43));
		}
		
		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
	}
}