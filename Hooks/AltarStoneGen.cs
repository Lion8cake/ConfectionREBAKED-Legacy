using TheConfectionRebirth.Tiles; //Code taken from exxo avalon origins 1.3 remake
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Hooks
{
    public class AltarStoneGen
    {
        public static void OnSmashAltar(On.Terraria.WorldGen.orig_SmashAltar orig, int i, int j)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient || !Main.hardMode || WorldGen.noTileActions || WorldGen.gen)
            {
                orig(i, j);
                return;
            }

            // Spawn evil or hallow blocks
            int randomNum = WorldGen.genRand.Next(3);
            int attempts = 0;
            while (randomNum != 2 && attempts++ < 1000)
            {
                int x = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                int y = WorldGen.genRand.Next((int)Main.rockLayer + 50, Main.maxTilesY - 300);

                // Tile must be active or stone
                if (!Main.tile[x, y].active() || Main.tile[x, y].type != 1)
                {
                    continue;
                }
                // Place evil
                if (randomNum == 0)
                {
                    if (WorldGen.crimson)
                    {
                        Main.tile[x, y].type = TileID.Crimstone;
                    }
                    else
                    {
                        Main.tile[x, y].type = TileID.Ebonstone;
                    }
                }
                // Place good
				else if (randomNum == 0)
                {
                    if (ConfectionWorldGeneration.confectionorHallow)
                    {
                        Main.tile[x, y].type = (ushort)ModContent.TileType<Creamstone>();
                    }
                    else
                    {
                        Main.tile[x, y].type = TileID.Pearlstone;
                    }
                }
                // Update clients
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendTileSquare(-1, x, y, 1);
                }
                break;
            }
        }
    }
}