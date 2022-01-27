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
	public class SugarGhoul : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sugar Ghoul");
			Main.npcFrameCount[npc.type] = 8;
		}

		public override void SetDefaults() {
			npc.width = 18;
			npc.height = 40;
			npc.damage = 50;
			npc.defense = 26;
			npc.lifeMax = 180;
			npc.HitSound = SoundID.NPCHit37;
			npc.DeathSound = SoundID.NPCDeath40;
			npc.value = 650f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = 524;
			animationType = 524;
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
		 if(spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.ZoneDesert && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection)
		   return spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.ZoneDesert && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection ? 1f : 0f;
		 return 0;
        }
	}
}
