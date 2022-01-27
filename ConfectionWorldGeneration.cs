using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.World.Generation;
using TheConfectionRebirth.Tiles;
using TheConfectionRebirth.Walls;
using System.IO;
using Terraria.GameContent.Biomes;
using Terraria.ModLoader.IO;

namespace TheConfectionRebirth
{
    public class ConfectionWorldGeneration : ModWorld
    {
	
	    public enum HallowVariant
        {
            hallow,
            confection,
            random
        }
		
		public static HallowVariant hallowMenuSelection = HallowVariant.random;
		
		public override void PreWorldGen()
        {
            if (hallowMenuSelection == HallowVariant.random)
            {
                hallowMenuSelection = (HallowVariant)WorldGen.genRand.Next(2);
            }
			confectionorHallow = hallowMenuSelection == HallowVariant.confection;
        }
		
        /// <summary>
        /// Changes value on generating hardmode biome
		/// Values:
        ///      false = Not Confection
        ///      true = Confection
		/// </summary>
        public static bool confectionorHallow;

        public override void Initialize()
        {
            confectionorHallow = false;
        }

        public override void ModifyHardmodeTasks(List<GenPass> list)
        {
		    if (confectionorHallow)
			{
				int index2 = list.FindIndex(genpass => ((string)genpass.Name).Equals("Hardmode Good"));
                int index3 = list.FindIndex(genpass => ((string)genpass.Name).Equals("Hardmode Evil"));
                if (Main.rand.NextBool(1)) // (2)) for 50% and (1)) for 100%
                {
                    list.Insert(index2 + 1, (GenPass)new PassLegacy("Confection Rebaked: Hardmode Good Alt", new WorldGenLegacyMethod(GenerateConfection)));
                    list.RemoveAt(index2);
                    list.RemoveAt(index3);
                }
			}
            
        }

        private static void GenerateConfection(GenerationProgress progress)
        {
            GenerateConfection();
        }

        public static void GenerateConfection()
        {
            WorldGen.IsGeneratingHardMode = true;
            if (Main.rand == null)
                Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
            float num1 = (float)WorldGen.genRand.Next(300, 400) * (1f / 1000f);
            float num2 = (float)WorldGen.genRand.Next(200, 300) * (1f / 1000f);
            int i1 = (int)((double)Main.maxTilesX * (double)num1);
            int i2 = (int)((double)Main.maxTilesX * (1.0 - (double)num1));
            int num3 = 1;
            if (WorldGen.genRand.Next(1) == 1)
            {
                i2 = (int)((double)Main.maxTilesX * (double)num1);
                i1 = (int)((double)Main.maxTilesX * (1.0 - (double)num1));
                num3 = -1;
            }
            int num4 = 1;
            if (WorldGen.dungeonX < Main.maxTilesX / 2)
                num4 = -1;
            if (num4 < 0)
            {
                if (i2 < i1)
                    i2 = (int)((double)Main.maxTilesX * (double)num2);
                else
                    i1 = (int)((double)Main.maxTilesX * (double)num2);
            }
            else if (i2 > i1)
                i2 = (int)((double)Main.maxTilesX * (1.0 - (double)num2));
            else
                i1 = (int)((double)Main.maxTilesX * (1.0 - (double)num2));
            GERunner(i1, 0, (float)(3 * num3), 5f, true);
            confectionorHallow = true;
            GERunner(i2, 0, (float)(3 * -num3), 5f, false);
            int num5 = (int)(25.0 * (double)((float)Main.maxTilesX / 4200f));
            ShapeData data = new ShapeData();
            int num6 = 0;
            while (num5 > 0)
            {
                if (++num6 % 15000 == 0)
                    --num5;
                Point point = WorldGen.RandomWorldPoint((int)Main.worldSurface - 100, 1, 190, 1);
                Tile tile1 = Main.tile[point.X, point.Y];
                Tile tile2 = Main.tile[point.X, point.Y - 1];
                byte type = 0;
                if (TileID.Sets.Crimson[(int)tile1.type])
                    type = (byte)(192 + WorldGen.genRand.Next(4));
                else if (TileID.Sets.Corrupt[(int)tile1.type])
                    type = (byte)(188 + WorldGen.genRand.Next(4));
                else if (TileID.Sets.Hallow[(int)tile1.type])
                    type = (byte)(200 + WorldGen.genRand.Next(4));
                if (tile1.active() && (int)type != 0 && !tile2.active())
                {
                    bool flag = WorldUtils.Gen(new Point(point.X, point.Y - 1), (GenShape)new ShapeFloodFill(10), Actions.Chain((GenAction)new Modifiers.IsNotSolid(), (GenAction)new Modifiers.OnlyWalls(new byte[30] { (byte)0, (byte)54, (byte)55, (byte)56, (byte)57, (byte)58, (byte)59, (byte)61, (byte)185, (byte)212, (byte)213, (byte)214, (byte)215, (byte)196, (byte)197, (byte)198, (byte)199, (byte)15, (byte)40, (byte)71, (byte)64, (byte)204, (byte)205, (byte)206, (byte)207, (byte)208, (byte)209, (byte)210, (byte)211, (byte)71 }), new Actions.Blank().Output(data)));
                    if (data.Count > 50 & flag)
                    {
                        WorldUtils.Gen(new Point(point.X, point.Y), (GenShape)new ModShapes.OuterOutline(data, true, true), (GenAction)new Actions.PlaceWall(type, true));
                        --num5;
                    }
                    data.Clear();
                }
            }
            confectionorHallow = true;
			//Main.NewText("The Ancient tastes of Sweet and Spice have also been released."); //Ill add this once I create the Sensation, you got to have to wait a bit :)
            AchievementsHelper.NotifyProgressionEvent(9);
            if (Main.netMode == NetmodeID.Server)
                Netplay.ResetSections();
            WorldGen.IsGeneratingHardMode = false;
        }

        public static void GERunner(int i, int j, float speedX = 0.0f, float speedY = 0.0f, bool good = true)
        {
            int num1 = (int)((double)WorldGen.genRand.Next(200, 250) * (double)(Main.maxTilesX / 4200));
            double num2 = (double)num1;
            Vector2 vector2_1;
            vector2_1.X = (float)i;
            vector2_1.Y = (float)j;
            Vector2 vector2_2;
            vector2_2.X = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            vector2_2.Y = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            if ((double)speedX != 0.0 || (double)speedY != 0.0)
            {
                vector2_2.X = speedX;
                vector2_2.Y = speedY;
            }
            bool flag = true;
            while (flag)
            {
                int num3 = (int)((double)vector2_1.X - num2 * 0.5);
                int num4 = (int)((double)vector2_1.X + num2 * 0.5);
                int num5 = (int)((double)vector2_1.Y - num2 * 0.5);
                int num6 = (int)((double)vector2_1.Y + num2 * 0.5);
                if (num3 < 0)
                    num3 = 0;
                if (num4 > Main.maxTilesX)
                    num4 = Main.maxTilesX;
                if (num5 < 0)
                    num5 = 0;
                if (num6 > Main.maxTilesY)
                    num6 = Main.maxTilesY;
                for (int i1 = num3; i1 < num4; ++i1)
                {
                    for (int j1 = num5; j1 < num6; ++j1)
                    {
                        if ((double)Math.Abs((float)i1 - vector2_1.X) + (double)Math.Abs((float)j1 - vector2_1.Y) < (double)num1 * 0.5 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.015))
                        {
                            if (good)
                                {
                                if (Main.tile[i1, j1].wall == 28 || Main.tile[i1, j1].wall == 1 || Main.tile[i1, j1].wall == 48 || Main.tile[i1, j1].wall == 49 || Main.tile[i1, j1].wall == 50 || Main.tile[i1, j1].wall == 51 || Main.tile[i1, j1].wall == 52 || Main.tile[i1, j1].wall == 53 || Main.tile[i1, j1].wall == 54 || Main.tile[i1, j1].wall == 55 || Main.tile[i1, j1].wall == 56 || Main.tile[i1, j1].wall == 57 || Main.tile[i1, j1].wall == 58 || Main.tile[i1, j1].wall == 188 || Main.tile[i1, j1].wall == 189 || Main.tile[i1, j1].wall == 190 || Main.tile[i1, j1].wall == 191 || Main.tile[i1, j1].wall == 61 || Main.tile[i1, j1].wall == 185 || Main.tile[i1, j1].wall == 212 || Main.tile[i1, j1].wall == 213 || Main.tile[i1, j1].wall == 214 || Main.tile[i1, j1].wall == 215 || Main.tile[i1, j1].wall == 192 || Main.tile[i1, j1].wall == 193 || Main.tile[i1, j1].wall == 194 || Main.tile[i1, j1].wall == 195 || Main.tile[i1, j1].wall == 3 || Main.tile[i1, j1].wall == 200 || Main.tile[i1, j1].wall == 201 || Main.tile[i1, j1].wall == 202 || Main.tile[i1, j1].wall == 203 || Main.tile[i1, j1].wall == 83)
                                {
                                    Main.tile[i1, j1].wall = (ushort)ModContent.WallType<Walls.CreamstoneWall>();
                                }
                                if (Main.tile[i1, j1].wall == 63 || Main.tile[i1, j1].wall == 65 || Main.tile[i1, j1].wall == 66 || Main.tile[i1, j1].wall == 68 || Main.tile[i1, j1].wall == 69 || Main.tile[i1, j1].wall == 70 || Main.tile[i1, j1].wall == 81)
                                {
                                    Main.tile[i1, j1].wall = (ushort)ModContent.WallType<Walls.CreamGrassWall>();
                                }
								else if (Main.tile[i1, j1].wall == 59 || Main.tile[i1, j1].wall == 171 || Main.tile[i1, j1].wall == 170 || Main.tile[i1, j1].wall == 196 || Main.tile[i1, j1].wall == 197 || Main.tile[i1, j1].wall == 198 || Main.tile[i1, j1].wall == 199 || Main.tile[i1, j1].wall == 16 || Main.tile[i1, j1].wall == 2)
                                {
                                    Main.tile[i1, j1].wall = (ushort)ModContent.WallType<Walls.CookieWall>();
                                }
                                else if (Main.tile[i1, j1].wall == 216 || Main.tile[i1, j1].wall == 217 || Main.tile[i1, j1].wall == 218 || Main.tile[i1, j1].wall == 219)
                                {
                                    Main.tile[i1, j1].wall = (ushort)ModContent.WallType<Walls.CreamsandstoneWall>();
                                }
                                else if (Main.tile[i1, j1].wall == 187 || Main.tile[i1, j1].wall == 220 || Main.tile[i1, j1].wall == 221 || Main.tile[i1, j1].wall == 222)
                                {
                                    Main.tile[i1, j1].wall = (ushort)ModContent.WallType<Walls.HardenedCreamsandWall>();
                                }
								else if (Main.tile[i1, j1].wall == 40)
                                {
                                    Main.tile[i1, j1].wall = (ushort)ModContent.WallType<Walls.CreamWall>();
                                }
								else if (Main.tile[i1, j1].wall == 71)
                                {
                                    Main.tile[i1, j1].wall = (ushort)ModContent.WallType<Walls.BlueIceWall>();
                                }
								else if (Main.tile[i1, j1].wall == 73)
                                {
                                    Main.tile[i1, j1].wall = (ushort)ModContent.WallType<Walls.PinkFairyFlossWall>();
                                }
                                if ((int)Main.tile[i1, j1].type == 2)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<CreamGrass>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
								else if ((int)Main.tile[i1, j1].type == 0)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<CookieBlock>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 1)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<Creamstone>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
								else if ((int)Main.tile[i1, j1].type == 179)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<Creamstone>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
								else if ((int)Main.tile[i1, j1].type == 180)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<Creamstone>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
								else if ((int)Main.tile[i1, j1].type == 181)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<Creamstone>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
								else if ((int)Main.tile[i1, j1].type == 182)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<Creamstone>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
								else if ((int)Main.tile[i1, j1].type == 183)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<Creamstone>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
								else if ((int)Main.tile[i1, j1].type == 381)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<Creamstone>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 147)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<CreamBlock>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 53 || (int)Main.tile[i1, j1].type == 123)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<Creamsand>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 23 || (int)Main.tile[i1, j1].type == 199)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<CreamGrass>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 25 || (int)Main.tile[i1, j1].type == 203)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<Creamstone>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 112 || (int)Main.tile[i1, j1].type == 234)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<Creamsand>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 161 || (int)Main.tile[i1, j1].type == 163 || (int)Main.tile[i1, j1].type == 200)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<BlueIce>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 396)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<Creamsandstone>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 397)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<HardenedCreamsand>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == TileID.Sapphire)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<CreamstoneSaphire>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == TileID.Ruby)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<CreamstoneRuby>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == TileID.Amethyst)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<CreamstoneAmethyst>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == TileID.Diamond)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<CreamstoneDiamond>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == TileID.Emerald)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<CreamstoneEmerald>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
								else if ((int)Main.tile[i1, j1].type == TileID.Topaz)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<CreamstoneTopaz>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
								else if ((int)Main.tile[i1, j1].type == 189)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<PinkFairyFloss>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
								else if ((int)Main.tile[i1, j1].type == 196)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<PurpleFairyFloss>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
								else if ((int)Main.tile[i1, j1].type == 460)
                                {
                                    Main.tile[i1, j1].type = (ushort)ModContent.TileType<BlueFairyFloss>();
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                            }
                            else if (WorldGen.crimson) //Crimson Generation 
                            {
                                if ((int)Main.tile[i1, j1].wall == 63 || (int)Main.tile[i1, j1].wall == 65 || ((int)Main.tile[i1, j1].wall == 66 || (int)Main.tile[i1, j1].wall == 68))
                                    Main.tile[i1, j1].wall = (byte)81;
                                else if ((int)Main.tile[i1, j1].wall == 216)
                                    Main.tile[i1, j1].wall = (byte)218;
                                else if ((int)Main.tile[i1, j1].wall == 187)
                                    Main.tile[i1, j1].wall = (byte)221;
                                if ((int)Main.tile[i1, j1].type == 2)
                                {
                                    Main.tile[i1, j1].type = (ushort)199;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 1)
                                {
                                    Main.tile[i1, j1].type = (ushort)203;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 53 || (int)Main.tile[i1, j1].type == 123)
                                {
                                    Main.tile[i1, j1].type = (ushort)234;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 109)
                                {
                                    Main.tile[i1, j1].type = (ushort)199;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 117)
                                {
                                    Main.tile[i1, j1].type = (ushort)203;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 116)
                                {
                                    Main.tile[i1, j1].type = (ushort)234;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 161 || (int)Main.tile[i1, j1].type == 164)
                                {
                                    Main.tile[i1, j1].type = (ushort)200;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 396)
                                {
                                    Main.tile[i1, j1].type = (ushort)401;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 397)
                                {
                                    Main.tile[i1, j1].type = (ushort)399;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                            }
                            else //Corruption Generation
                            {
                                if ((int)Main.tile[i1, j1].wall == 63 || (int)Main.tile[i1, j1].wall == 65 || ((int)Main.tile[i1, j1].wall == 66 || (int)Main.tile[i1, j1].wall == 68))
                                    Main.tile[i1, j1].wall = (byte)69;
                                else if ((int)Main.tile[i1, j1].wall == 216)
                                    Main.tile[i1, j1].wall = (byte)217;
                                else if ((int)Main.tile[i1, j1].wall == 187)
                                    Main.tile[i1, j1].wall = (byte)220;
                                if ((int)Main.tile[i1, j1].type == 2)
                                {
                                    Main.tile[i1, j1].type = (ushort)23;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 1)
                                {
                                    Main.tile[i1, j1].type = (ushort)25;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 53 || (int)Main.tile[i1, j1].type == 123)
                                {
                                    Main.tile[i1, j1].type = (ushort)112;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 109)
                                {
                                    Main.tile[i1, j1].type = (ushort)23;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 117)
                                {
                                    Main.tile[i1, j1].type = (ushort)25;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 116)
                                {
                                    Main.tile[i1, j1].type = (ushort)112;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 161 || (int)Main.tile[i1, j1].type == 164)
                                {
                                    Main.tile[i1, j1].type = (ushort)163;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 396)
                                {
                                    Main.tile[i1, j1].type = (ushort)400;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                                else if ((int)Main.tile[i1, j1].type == 397)
                                {
                                    Main.tile[i1, j1].type = (ushort)398;
                                    WorldGen.SquareTileFrame(i1, j1, true);
                                }
                            }
                        }
                    }
                }
                vector2_1 += vector2_2;
                vector2_2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                if ((double)vector2_2.X > (double)speedX + 1.0)
                    vector2_2.X = speedX + 1f;
                if ((double)vector2_2.X < (double)speedX - 1.0)
                    vector2_2.X = speedX - 1f;
                if ((double)vector2_1.X < (double)-num1 || (double)vector2_1.Y < (double)-num1 || ((double)vector2_1.X > (double)(Main.maxTilesX + num1) || (double)vector2_1.Y > (double)(Main.maxTilesX + num1)))
                    flag = false;
            }
        }
		
		public override TagCompound Save()
        {
            var toSave = new TagCompound
            {
                { "TheConfectionRebirth:confectionorHallow", confectionorHallow },
            };
            return toSave;
        }

        public override void Load(TagCompound tag)
        {
            if (tag.ContainsKey("TheConfectionRebirth:confectionorHallow"))
            {
                confectionorHallow = tag.Get<bool>("TheConfectionRebirth:confectionorHallow");
            }
        }
    }
}
