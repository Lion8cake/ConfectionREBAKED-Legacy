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
	public class StripedPigron : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Striped Pigron");
			Main.npcFrameCount[npc.type] = 14;
		}

		public override void SetDefaults() {
			npc.width = 48;
			npc.height = 40;
			npc.damage = 70;
			npc.defense = 16;
			npc.lifeMax = 210;
			npc.HitSound = SoundID.NPCHit27;
			npc.DeathSound = SoundID.NPCDeath30;
			npc.value = 2000f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 2;
			aiType = 170;
		    animationType = 170;
			banner = npc.type;
			bannerItem = ModContent.ItemType<StripedPigronBanner>();
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
		 if(spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection && spawnInfo.player.ZoneSnow)
		   return spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection && spawnInfo.player.ZoneSnow ? .05f : 0f;
		 return 0;
        }
	}
}
