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
using TheConfectionRebirth.Gores;

namespace TheConfectionRebirth.NPCs
{
	public class SweetGummy_1 : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sweet Gummy");
			Main.npcFrameCount[npc.type] = 16; 
		}

		public override void SetDefaults() {
			npc.width = 18;
			npc.height = 40;
			npc.damage = 60;
			npc.defense = 26;
			npc.lifeMax = 180;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 700f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = NPCID.Mummy;
			animationType = NPCID.Mummy;
			banner = npc.type;
			bannerItem = ModContent.ItemType<SweetGummyBanner>();
		}
		
		public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, 13);
				Gore.NewGore(npc.position, npc.velocity, 12);
				Gore.NewGore(npc.position, npc.velocity, 11);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection && spawnInfo.player.ZoneDesert && spawnInfo.player.ZoneOverworldHeight)
				return spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection && spawnInfo.player.ZoneDesert && spawnInfo.player.ZoneOverworldHeight ? .31f : 0f;
			return 0;
		}
	}
}