using TheConfectionRebirth.Items;
using TheConfectionRebirth.Tiles;
using TheConfectionRebirth.Walls;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.World;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace TheConfectionRebirth
{
	public class ConfectionWorld : ModWorld
	{
		public static int confectionTiles;
		public static int confectionsandTiles;
		public static int confectionsnowTiles;

        public override void ResetNearbyTileEffects()
        {
			confectionTiles = 0;
        }

        public override void TileCountsAvailable(int[] tileCounts) {
			Main.snowTiles += tileCounts[ModContent.TileType<CreamBlock>()] 
				+ tileCounts[ModContent.TileType<BlueIce>()];
			Main.sandTiles += tileCounts[ModContent.TileType<Creamsand>()] 
				+ tileCounts[ModContent.TileType<HardenedCreamsand>()] 
				+ tileCounts[ModContent.TileType<Creamsandstone>()];
			confectionTiles = tileCounts[ModContent.TileType<Creamstone>()] 
				+ tileCounts[ModContent.TileType<CookieBlock>()] 
				+ tileCounts[ModContent.TileType<CreamGrass>()]
				+ tileCounts[ModContent.TileType<CreamBlock>()]
				+ tileCounts[ModContent.TileType<BlueIce>()] 
				+ tileCounts[ModContent.TileType<Creamsand>()]
				+ tileCounts[ModContent.TileType<HardenedCreamsand>()]
				+ tileCounts[ModContent.TileType<Creamsandstone>()];
		}
		
		public static void InfectionSpread(int i, int j, string InfectionTypeCapitalized) //Thanks to cace for the tile spread code
        {
            int InfectionType; // initializing the variable where the type of spread will be ultimately stored
            switch (InfectionTypeCapitalized) // converting from a string to a corresponding int
            {
                case "Corruption":
                    InfectionType = 0;
                    break;
                case "Crimson":
                    InfectionType = 1;
                    break;
                case "Hallow":
                    InfectionType = 2;
                    break;
                case "Confection":
                    InfectionType = 3;
                    break;
                default:
                    InfectionType = 0;
                    break;
            }

            // the following arrays are designed to be able to be easily extended. adding a new biome to convert blocks to can be done by adding the corresponding blocks to each of the convertTo arrays
                // adding a new spreading biome type also requires an id to be given to that biome in the above switch case
            // similarly to adding new biomes, more blocks can be made to spread by appending the convertFrom array and adding a corresponding convertTo[n] array to the end 

            int[] convertFrom = { TileID.Grass, TileID.Stone, TileID.Mud, TileID.IceBlock, TileID.Sand, TileID.Sandstone, TileID.HardenedSand, TileID.Dirt, TileID.JungleGrass, TileID.SnowBlock, TileID.Cloud, TileID.RainCloud, TileID.SnowCloud, TileID.Amethyst, TileID.Topaz, TileID.Sapphire, TileID.Emerald, TileID.Ruby, TileID.Diamond, TileID.CorruptGrass, TileID.FleshGrass, TileID.HallowedGrass, TileType<CreamGrass>(), TileType<CookieBlock>(), WallID.Grass, WallID.Flower, WallID.Jungle, WallID.Stone, WallID.HardenedSand, WallID.Sandstone }; // each item has a corresponding array in the convertTo array^2

            int[][] convertTo = new int[30][]; // each item corresponds to an item on the convertFrom array, and each item in each sub-array corresponds to a value of int InfectionType
                convertTo[0] = new int[] { TileID.CorruptGrass, TileID.FleshGrass, TileID.HallowedGrass, TileType<CreamGrass>() };
                convertTo[1] = new int[] { TileID.Ebonstone, TileID.Crimstone, TileID.Pearlstone, TileType<Creamstone>() };
				convertTo[2] = new int[] { TileID.Dirt, TileID.Dirt, TileID.Mud, TileID.Mud };
                convertTo[3] = new int[] { TileID.CorruptIce, TileID.FleshIce, TileID.HallowedIce, TileType<BlueIce>() };
                convertTo[4] = new int[] { TileID.Ebonsand, TileID.Crimsand, TileID.Pearlsand, TileType<Creamsand>() };
                convertTo[5] = new int[] { TileID.CorruptSandstone, TileID.CrimsonSandstone, TileID.HallowSandstone, TileType<Creamsandstone>() };
                convertTo[6] = new int[] { TileID.CorruptHardenedSand, TileID.CrimsonHardenedSand, TileID.HallowHardenedSand, TileType<HardenedCreamsand>() };
				convertTo[7] = new int[] { TileID.CorruptGrass, TileID.FleshGrass, TileID.JungleGrass, TileID.JungleGrass };
				convertTo[8] = new int[] { TileID.Dirt, TileID.Dirt, TileID.Dirt, TileType<CookieBlock>() };
				convertTo[9] = new int[] { TileID.SnowBlock, TileID.SnowBlock, TileID.SnowBlock, TileType<CreamBlock>() };
				convertTo[10] = new int[] { TileID.Cloud, TileID.Cloud, TileID.Cloud, TileType<PinkFairyFloss>() };
				convertTo[11] = new int[] { TileID.RainCloud, TileID.RainCloud, TileID.RainCloud, TileType<PurpleFairyFloss>() };
				convertTo[12] = new int[] { TileID.SnowCloud, TileID.SnowCloud, TileID.SnowCloud, TileType<BlueFairyFloss>() };
				convertTo[13] = new int[] { TileID.Amethyst, TileID.Amethyst, TileID.Amethyst, TileType<CreamstoneAmethyst>() };
				convertTo[14] = new int[] { TileID.Topaz, TileID.Topaz, TileID.Topaz, TileType<CreamstoneTopaz>() };
				convertTo[15] = new int[] { TileID.Sapphire, TileID.Sapphire, TileID.Sapphire, TileType<CreamstoneSaphire>() };
				convertTo[16] = new int[] { TileID.Emerald, TileID.Emerald, TileID.Emerald, TileType<CreamstoneEmerald>() };
				convertTo[17] = new int[] { TileID.Ruby, TileID.Ruby, TileID.Ruby, TileType<CreamstoneRuby>() };
				convertTo[18] = new int[] { TileID.Diamond, TileID.Diamond, TileID.Diamond, TileType<CreamstoneDiamond>() };
				convertTo[19] = new int[] { TileID.CorruptGrass, TileID.CorruptGrass, TileID.CorruptGrass, TileType<CreamGrass>() }; //This allows the confection to convert corrupt grass
				convertTo[20] = new int[] { TileID.FleshGrass, TileID.FleshGrass, TileID.HallowedGrass, TileID.FleshGrass }; //This allows the hallow to convert flesh grass (aka crimson grass)
				convertTo[21] = new int[] { TileID.CorruptGrass, TileID.HallowedGrass, TileID.HallowedGrass, TileType<CreamGrass>() }; 
				convertTo[22] = new int[] { TileType<CreamGrass>(), TileID.FleshGrass, TileID.HallowedGrass, TileType<CreamGrass>() };
				convertTo[23] = new int[] { TileType<CookieBlock>(), TileID.Dirt, TileID.Dirt, TileType<CookieBlock>() }; //allows the crimson and hallow to convert cookie block to dirt. Makes the grass that isn't converted not look so odd with cookie under it
				//This next part is the walls that is converted
				convertTo[24] = new int[] { WallID.CorruptGrassUnsafe, WallID.CrimsonGrassUnsafe, WallID.HallowedGrassUnsafe, WallType<CreamGrassWall>() };
				convertTo[25] = new int[] { WallID.CorruptGrassUnsafe, WallID.CrimsonGrassUnsafe, WallID.HallowedGrassUnsafe, WallType<CreamGrassWall>() };
				convertTo[26] = new int[] { WallID.CorruptGrassUnsafe, WallID.CrimsonGrassUnsafe, WallID.Grass, WallID.Grass };
				convertTo[27] = new int[] { WallID.EbonstoneUnsafe, WallID.CrimstoneUnsafe, WallID.PearlstoneBrickUnsafe, WallType<CreamstoneWall>() };
				convertTo[28] = new int[] { WallID.CorruptHardenedSand, WallID.CrimsonHardenedSand, WallID.HallowHardenedSand, WallType<HardenedCreamsandWall>() };
				convertTo[29] = new int[] { WallID.CorruptSandstone, WallID.CrimsonSandstone, WallID.HallowSandstone, WallType<CreamsandstoneWall>() };
				
            int left = i - 3; // defining the bounds of the space which will be checked for corruptable blocks
            int right = i + 3;
            int top = j - 3;
            int bottom = j + 3;
            if (left < 0) // making sure the coords to detect blocks are within the bounds of the world
            {
                left = 0;
            }
            if (right > Main.maxTilesX)
            {
                right = Main.maxTilesX;
            }
            if (top < 0)
            {
                top = 0;
            }
            if (bottom > Main.maxTilesY)
            {
                bottom = Main.maxTilesY;
            }

            int spreadChance; // higher number means slower spread speed
            if (!Main.hardMode)
            {
                spreadChance = 49800; // variable is not used unless world is in hardmode. value here is arbitrary but as a fallback is still very high
            } else
            {
                if (NPC.downedPlantBoss) // makes spreading slower if plantera has been beaten
                {
                    spreadChance = 97600;
                } else
                {
                    spreadChance = 2147483647;//fuck you im using the 32 bit inigur limit to make sure the biome doesn't spread during pre-hardmode
                }
            }

            if (Main.hardMode) 
            {
                for (int k = left; k <= right; k++)
                {
                    for (int l = top; l <= bottom; l++)
                    {
                        for (int block = 0; block < convertFrom.Length; block++) 
                        {
                            if (WorldGen.genRand.Next(spreadChance) == 0)
                            {
                                if (Main.tile[k, l].type == convertFrom[block])
                                {
                                    Main.tile[k, l].type = (ushort)convertTo[block][InfectionType];
                                }
                            }
                        }
                    }
                }
            }
        }
	}
}