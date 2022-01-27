using TheConfectionRebirth.Items.Banners;
using TheConfectionRebirth.Gores;
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
	public class Iscreamer_2 : ModNPC
	{
	
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Iscreamer");  
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.width = 60;
			npc.height = 60;
			npc.damage = 50;
			npc.defense = 22;
			npc.lifeMax = 400;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 60f;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 22;
			aiType = NPCID.FloatyGross;
			banner = npc.type;
			bannerItem = ModContent.ItemType<IscreamerBanner>();
		}
		
		public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0)
		{
			Gore.NewGore(npc.position, npc.velocity, 13);
			Gore.NewGore(npc.position, npc.velocity, 12);
			Gore.NewGore(npc.position, npc.velocity, 11);
		}
		}
		
	int speed = 10;
        int maxFrames = 3;
        int frame;
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            if (npc.frameCounter >= speed)
            {
                frame++;
                npc.frameCounter = 0;
            }

            if (frame > maxFrames)
                frame = 0;
            
            npc.frame.Y = frame * frameHeight;
            npc.spriteDirection = npc.direction;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
		 if(spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection && spawnInfo.player.ZoneSnow)
		   return spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection && spawnInfo.player.ZoneSnow ? .2f : 0f;
		 return 0;
        }
  }	
}
