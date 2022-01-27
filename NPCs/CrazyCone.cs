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
	
	public class CrazyCone : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Crazy Cone");
			Main.npcFrameCount[npc.type] = 6; 
		}
		
		public override void SetDefaults() {
			npc.width = 36;
			npc.height = 36;
			npc.damage = 80;
			npc.defense = 18;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 1000f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 23;
			aiType = NPCID.EnchantedSword;
			animationType = NPCID.EnchantedSword;
			banner = npc.type;
			bannerItem = ModContent.ItemType<CrazyConeBanner>();
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
		   return spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection ? .08f : 0f;
		 return 0;
        }
	}
}