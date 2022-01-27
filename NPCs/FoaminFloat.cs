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
	public class FoaminFloat : ModNPC
	{
	
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Foamin' Float");  
		}

		public override void SetDefaults() {
			npc.width = 40;
			npc.height = 40;
			npc.damage = 45;
			npc.defense = 8;
			npc.lifeMax = 140;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 500f;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 22;
			aiType = NPCID.FloatyGross;
			banner = npc.type;
			bannerItem = ModContent.ItemType<FoaminFloatBanner>();
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
		 if(spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection)
		   return spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection ? .1f : 0f;
		 return 0;
        }
  }	
}
