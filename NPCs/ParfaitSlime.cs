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
	
	public class ParfaitSlime : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Parfait Slime");
			Main.npcFrameCount[npc.type] = 2; 
		}
		
		public override void SetDefaults() {
			npc.width = 32;
			npc.height = 32;
			npc.damage = 70;
			npc.defense = 16;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 400f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 1;
			aiType = NPCID.Crimslime;
			animationType = NPCID.Crimslime;
			banner = npc.type;
			bannerItem = ModContent.ItemType<ParfaitSlimeBanner>();
		}
		
		public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0) {
				Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<CreamDust>());
			}
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
		 if(spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection)
		   return spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection ? 1.00f : 0f;
		 return 0;
        }
	}
}