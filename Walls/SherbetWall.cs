using Microsoft.Xna.Framework;
using TheConfectionRebirth.Items.Placeable;
using TheConfectionRebirth.Dusts;
using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Walls
{
	public class SherbetWall : ModWall
	{
		public override void SetDefaults() {
			Main.wallHouse[Type] = true;
			dustType = ModContent.DustType<SherbetDust>();
			drop = ModContent.ItemType<Items.Placeable.SherbetWall>();
			AddMapEntry(new Color(74, 61, 43));
		}
		
		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
		
		
		public override void AnimateWall(ref byte frame, ref byte frameCounter)
		{
			frameCounter++;
			if (frameCounter > 5)
			{
				frameCounter = 0;
				frame++;
				if (frame > 12)
				{
					frame = 0;
				}
			}
		}
	}
}