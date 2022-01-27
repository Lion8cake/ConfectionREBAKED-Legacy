using TheConfectionRebirth.Items.Placeable;
using TheConfectionRebirth.Items.Weapons;
using TheConfectionRebirth.Items.Banners;
using TheConfectionRebirth.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheConfectionRebirth.Gores;

namespace TheConfectionRebirth.NPCs
{
    public class ConfectionAlternateDrops : GlobalNPC
    {
        public override bool PreNPCLoot(NPC npc)
        {
            if (npc.type == NPCID.SkeletronPrime || npc.type == NPCID.TheDestroyer || npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
            {
                NPCLoader.blockLoot.Add(ItemID.HallowedBar);
            }
			if (npc.type == NPCID.WallofFlesh)
            {
                NPCLoader.blockLoot.Add(ItemID.Pwnhammer);
            }
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCrimson && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCorrupt)
			{
			    NPCLoader.blockLoot.Add(ItemID.SoulofNight);
			}
            return base.PreNPCLoot(npc);
        }

        public override void NPCLoot(NPC npc)
        {
            if (!Main.expertMode)
            {
                if (ConfectionWorldGeneration.confectionorHallow)
                {
                    if (npc.type == NPCID.SkeletronPrime || npc.type == NPCID.TheDestroyer)
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<NeapoliniteOre>(), Main.rand.Next(75, 150));
                    }
                    int TS = NPC.CountNPCS(NPCID.Spazmatism);
                    int TR = NPC.CountNPCS(NPCID.Retinazer);
                    if (TS == 0 && TR == 1)
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<NeapoliniteOre>(), Main.rand.Next(75, 150));
                    }
                    if (TS == 1 && TR == 0)
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<NeapoliniteOre>(), Main.rand.Next(75, 150));
                    }
                }
                else
                {
                    if (npc.type == NPCID.SkeletronPrime || npc.type == NPCID.TheDestroyer)
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<HallowedOre>(), Main.rand.Next(75, 150));
                    }
                    int TS = NPC.CountNPCS(NPCID.Spazmatism);
                    int TR = NPC.CountNPCS(NPCID.Retinazer);
                    if (TS == 0 && TR == 1)
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<HallowedOre>(), Main.rand.Next(75, 150));
                    }
                    if (TS == 1 && TR == 0)
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<HallowedOre>(), Main.rand.Next(75, 150));
                    }
                }
            }
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneRockLayerHeight && Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCrimson && !Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCorrupt && Main.hardMode == true)
			{
			    if (Main.rand.Next(5) == 0)
				{
			    Item.NewItem(npc.getRect(), ModContent.ItemType<SoulofSpite>(), Main.rand.Next(1, 1));
				}
			}
			if (npc.type == NPCID.WallofFlesh)
            {
                 Item.NewItem(npc.getRect(), ModContent.ItemType<HeavenGift>(), Main.rand.Next(1, 1));
            }
        }
    }
    public class neapolinitebardrop2 : GlobalItem
    {
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag" && (arg == ItemID.SkeletronPrimeBossBag || arg == ItemID.DestroyerBossBag || arg == ItemID.TwinsBossBag))
            {
			    NPCLoader.blockLoot.Add(ItemID.HallowedBar);
                if (ConfectionWorldGeneration.confectionorHallow)
                {
                    player.QuickSpawnItem(ModContent.ItemType<NeapoliniteOre>(), Main.rand.Next(75, 150));
                }
                else
                {
                    player.QuickSpawnItem(ModContent.ItemType<HallowedOre>(), Main.rand.Next(75, 150));
                }
            }
			if (context == "bossBag" && (arg == ItemID.WallOfFleshBossBag))
            {
			    NPCLoader.blockLoot.Add(ItemID.Pwnhammer);
            }
        }
    }
}