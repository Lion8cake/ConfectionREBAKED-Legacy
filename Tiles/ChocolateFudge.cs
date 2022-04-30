using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheConfectionRebirth.Buffs;

namespace TheConfectionRebirth.Tiles
{
	public class ChocolateFudge : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMerge[Type][mod.TileType("CookieBlock")] = true;
			Main.tileMerge[Type][mod.TileType("CreamGrass")] = true;
			Main.tileMerge[Type][mod.TileType("HallowedOre")] = true;
			Main.tileMerge[Type][mod.TileType("NeapoliniteOre")] = true;
			Main.tileMerge[Type][mod.TileType("CreamstoneBrick")] = true;
			Main.tileMerge[Type][mod.TileType("CreamWood")] = true;
			Main.tileMerge[Type][mod.TileType("CreamBlock")] = true;
            Main.tileMerge[Type][161] = true;
            Main.tileMerge[Type][163] = true;
            Main.tileMerge[Type][164] = true;
            Main.tileMerge[Type][200] = true;
            Main.tileMerge[Type][147] = true;
            Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			dustType = mod.DustType("FudgeDust");
			drop = ModContent.ItemType<Items.Placeable.ChocolateFudge>();
			AddMapEntry(new Color(108, 61, 49));
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
		
		public override void RandomUpdate(int i, int j)
        {
          ConfectionWorld.InfectionSpread(i, j, "Confection");
        }
		
		public override void NearbyEffects(int i, int j, bool closer)
		{
			Player player = Main.LocalPlayer;
			if ((int)Vector2.Distance(player.Center / 16f, new Vector2((float)i, (float)j)) <= 1)
			{
				player.AddBuff(ModContent.BuffType<Fudged>(), Main.rand.Next(10, 20));
			}
		}
	}
}