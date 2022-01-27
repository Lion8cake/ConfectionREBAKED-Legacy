using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ModLoader;
using Terraria.World.Generation;
using TheConfectionRebirth.Items.Placeable;
using TheConfectionRebirth.Tiles;
using TheConfectionRebirth.Items.Accessories;
using TheConfectionRebirth.Items.Weapons;

namespace TheConfectionRebirth //All credit goes out to Basically I am Fox and go support him for his other mods
{
    public class ConfectionBiomechestGen : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int index2 = tasks.FindIndex((Predicate<GenPass>)(genpass => ((string)genpass.Name).Equals("Dungeon")));
            if (index2 != -1)
                tasks.Insert(index2 + 1, (GenPass)new PassLegacy("Confection Rebaked: Biome Chests", new WorldGenLegacyMethod(GenerateBiomeChests)));
        }

        public static void GenerateBiomeChests(GenerationProgress progress)
        {
            progress.Message = "Confection Rebaked: Biome Chests";
            int minValue = (int)typeof(WorldGen).GetField("dMinX", BindingFlags.Static | BindingFlags.NonPublic).GetValue((object)null) + 25;
            int maxValue1 = (int)typeof(WorldGen).GetField("dMaxX", BindingFlags.Static | BindingFlags.NonPublic).GetValue((object)null) - 25;
            int maxValue2 = (int)typeof(WorldGen).GetField("dMaxY", BindingFlags.Static | BindingFlags.NonPublic).GetValue((object)null) - 25;
            int[] numArray1 = new int[1]
            {
        ModContent.TileType<ConfectionBiomeChestTile>()
            };
            int[] numArray2 = new int[1]
            {
        ModContent.ItemType<PopRocket>()
            };
            int[] numArray3 = new int[1] { 1 };
            for (int index = 0; index < numArray1.Length; ++index)
            {
                Chest chest = (Chest)null;
                int num = 0;
                while (chest == null && num < 1000)
                {
                    ++num;
                    int i = WorldGen.genRand.Next(minValue, maxValue1);
                    int j = WorldGen.genRand.Next((int)Main.worldSurface, maxValue2);
                    if (Main.wallDungeon[(int)Main.tile[i, j].wall] && !Main.tile[i, j].active())
                        chest = AddChestWithLoot(i, j, (ushort)numArray1[index], tileStyle: numArray3[index]);
                }
                if (chest != null)
                {
                    chest.item[0].SetDefaults(numArray2[index], false);
                    chest.item[0].Prefix(-1);
                }
            }
        }

        internal static Chest AddChestWithLoot(
      int i,
      int j,
      ushort type = 21,
      uint startingSlot = 1,
      int tileStyle = 0)
        {
            int index = -1;
            for (; j < Main.maxTilesY - 210; ++j)
            {
                if (WorldGen.SolidTile(i, j))
                {
                    index = WorldGen.PlaceChest(i - 1, j - 1, type, style: tileStyle);
                    break;
                }
            }
            if (index < 0)
                return (Chest)null;
            Chest chest = Main.chest[index];
            if (Main.rand.Next(0) == 0)
            {
                PutItemInChest(ref chest, ModContent.ItemType<WildAiryBlue>(), 1, 1, true);
				PutItemInChest(ref chest, 279, 20, 40, true);
				PutItemInChest(ref chest, 41, 30, 50, true);
				PutItemInChest(ref chest, 188, 2, 5, true);
				PutItemInChest(ref chest, 297, 0, 2, true);
				PutItemInChest(ref chest, 303, 0, 2, true);
				PutItemInChest(ref chest, 73, 1, 2, true);
                int minQuantity = WorldGen.genRand.Next(30, 120);
                if (minQuantity > 100)
                {
                    PutItemInChest(ref chest, 0, 1, 1, true);
                    minQuantity -= 100;
                }
                PutItemInChest(ref chest, 0, minQuantity, 0, true);
            }

            return chest;
            void PutItemInChest(ref Chest c, int id, int minQuantity, int maxQuantity, bool condition)
            {
                if (!condition)
                    return;
                c.item[(int)startingSlot].SetDefaults(id, false);
                if (minQuantity > 0)
                {
                    if (maxQuantity < minQuantity)
                        maxQuantity = minQuantity;
                    c.item[(int)startingSlot].stack = WorldGen.genRand.Next(minQuantity, maxQuantity + 1);
                }
                startingSlot++;
            }
        }
    }
}
