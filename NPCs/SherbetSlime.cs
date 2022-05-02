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
using TheConfectionRebirth.Dusts;

namespace TheConfectionRebirth.NPCs
{
	
	public class SherbetSlime : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sherbet Slime");
			Main.npcFrameCount[npc.type] = 2; 
		}

		public override void SetDefaults() {
			npc.width = 44;
			npc.height = 34;
			npc.damage = 77;
			npc.defense = 22;
			npc.lifeMax = 420;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 2000f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 1;
			aiType = NPCID.Crimslime;
			animationType = NPCID.Crimslime;
			banner = npc.type;
			bannerItem = ModContent.ItemType<SherbetSlimeBanner>();
		} 
		
		public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0) {
				Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<SherbetDust>());
			}
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
		 if(spawnInfo.player.ZoneOverworldHeight && Main.raining && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection)
		   return spawnInfo.player.ZoneOverworldHeight && Main.raining && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection ? .1f : 0f;// Mod Biome // if day time 
		 return 0;
        }
	}
}