using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheConfectionRebirth.Gores;

namespace TheConfectionRebirth.NPCs
{
	public class BigMimicConfection : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Confection Mimic");
			Main.npcFrameCount[npc.type] = 14;
		}

		public override void SetDefaults() {
			npc.width = 30;
			npc.height = 40;
			npc.damage = 180;
			npc.defense = 34;
			npc.lifeMax = 3500;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 30000f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 87;
			aiType = NPCID.BigMimicHallow;
			animationType = NPCID.BigMimicHallow;
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
		   return spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection ? .01f : 0f;
		 return 0;
        }
	}
}
