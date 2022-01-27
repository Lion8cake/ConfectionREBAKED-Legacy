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
	public class CreamSwollower : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cream Swollower");  
			Main.npcFrameCount[npc.type] = 4; 
		}

		public override void SetDefaults() {
			npc.width = 40;
			npc.height = 40;
			npc.damage = 50;
			npc.defense = 10;
			npc.lifeMax = 360;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 400f;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.behindTiles = true;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 103;
			aiType = NPCID.SandShark;
			animationType = NPCID.SandShark;
			banner = npc.type;
			bannerItem = ModContent.ItemType<CreamSwollowerBanner>();
		}
		
	    public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
		 if(spawnInfo.player.ZoneSandstorm && spawnInfo.player.ZoneDesert && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection)
		   return spawnInfo.player.ZoneSandstorm && spawnInfo.player.ZoneDesert && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection ? .5f : 0f;
		 return 0;
        }
  }
}
