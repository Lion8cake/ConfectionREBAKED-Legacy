using TheConfectionRebirth.Dusts;
using TheConfectionRebirth.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TheConfectionRebirth.Projectiles;

namespace TheConfectionRebirth.Tiles
{
    public class BlueFairyFloss : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][mod.TileType("CreamGrass")] = true;
            Main.tileMerge[Type][mod.TileType("Creamstone")] = true;
            Main.tileMerge[Type][mod.TileType("CreamWood")] = true;
			Main.tileMerge[Type][mod.TileType("PurpleFairyFloss")] = true;
			Main.tileMerge[Type][mod.TileType("PinkFairyFloss")] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = false;
            drop = ModContent.ItemType<Items.Placeable.BlueFairyFloss>();
            AddMapEntry(new Color(78, 191, 252));
			dustType = mod.DustType("FairyFlossDust3");
        }
		
		public override void RandomUpdate(int i, int j)
        {
          ConfectionWorld.InfectionSpread(i, j, "Confection");
        }
		
		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (!Main.gamePaused && closer && Main.rand.NextBool(1))
			{
				int tileLocationY = j + 1;
				if (Main.tile[i, tileLocationY] != null && !Main.tile[i, tileLocationY].active() && Main.netMode != 1)
				{
					Projectile.NewProjectile(i * 16 + 8, tileLocationY * 16 + 0, 0f, 0.1f, ModContent.ProjectileType<BlueFairyFlossRain>(), 25, 2f, Main.myPlayer);
				}
			}
		}
    }
}