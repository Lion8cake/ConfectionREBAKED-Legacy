using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Walls
{
	public class HardenedCreamsandWall : ModWall
	{
		public override void SetDefaults() {
			Main.wallHouse[Type] = false;
			AddMapEntry(new Color(74, 61, 43));
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