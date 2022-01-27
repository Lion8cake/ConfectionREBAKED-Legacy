using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Walls
{
	public class CreamsandstoneWall : ModWall
	{
		public override void SetDefaults() {
			Main.wallHouse[Type] = false;
			AddMapEntry(new Color(74, 61, 43));
		}
		
		public override void RandomUpdate(int i, int j)
        {
          ConfectionWorld.InfectionSpread(i, j, "Confection");
        }
	}
}