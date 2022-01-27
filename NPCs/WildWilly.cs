using TheConfectionRebirth.Items.Banners;
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

namespace TheConfectionRebirth.NPCs
{
	public class WildWilly : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Wild Willy");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults() {
			npc.width = 18;
			npc.height = 40;
			npc.damage = 30;
			npc.defense = 20;
			npc.lifeMax = 800;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 10000f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = NPCID.Zombie;
			animationType = NPCID.Zombie;
			banner = npc.type;
			bannerItem = ModContent.ItemType<WildWillyBanner>();
		}
		
		public override void HitEffect(int hitDirection, double damage) {
            if (npc.life <= 0) {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WillyGore1"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WillyGore2"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WillyGore3"));
            }
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
		 if(spawnInfo.player.ZoneOverworldHeight && !Main.dayTime && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection)
		   return spawnInfo.player.ZoneOverworldHeight && !Main.dayTime && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection ? .01f : 0f;
		 return 0;
        }
	}
}
