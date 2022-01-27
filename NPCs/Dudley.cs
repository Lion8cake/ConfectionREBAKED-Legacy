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
	public class Dudley : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dudley");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.width = 26;
			npc.height = 24;
			npc.damage = 48;
			npc.defense = 22;
			npc.lifeMax = 320;
			npc.HitSound = SoundID.NPCHit13;
			npc.DeathSound = SoundID.NPCDeath12;
			npc.value = 650f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 67;
			aiType = 360;
			banner = npc.type;
			bannerItem = ModContent.ItemType<DudleyBanner>();
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
		 if(spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.ZoneDesert && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection)
		   return spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.ZoneDesert && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection ? 1f : 0f;
		 return 0;
        }
		
		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<CritterBlood>());
			}
		}
		
		public override void FindFrame(int frameHeight)
    	{
	    	npc.frameCounter += 1.0;
    		if (npc.frameCounter > 8.0)
	      	{
	    		npc.frameCounter = 0.0;
    			npc.frame.Y += frameHeight;
	    		if (npc.frame.Y > frameHeight * 2)
	     		{
	    			npc.frame.Y = 0;
	    		}
     		}
    	}
	}
}
