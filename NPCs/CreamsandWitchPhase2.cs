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
using TheConfectionRebirth.NPCs;

namespace TheConfectionRebirth.NPCs
{
	public class CreamsandWitchPhase2 : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Creamsand Witch");
			Main.npcFrameCount[npc.type] = 16; 
		}

		public override void SetDefaults() {
			npc.width = 18;
			npc.height = 40;
			npc.damage = 85;
			npc.defense = 15;
			npc.lifeMax = 2000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 1000f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = NPCID.ChaosElemental;
			animationType = NPCID.Mummy;
			banner = npc.type;
    		bannerItem = ModContent.ItemType<CreamsandWitchBanner>();
		}
		
		public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, 13);
				Gore.NewGore(npc.position, npc.velocity, 12);
				Gore.NewGore(npc.position, npc.velocity, 11);
			}
		}
		
		public override void AI()
		{
			npc.ai[0] += 1f;
			if (Main.rand.NextBool(500) && NPC.CountNPCS(ModContent.NPCType<Hunger>()) < 25)
			{
				npc.ai[0] = 0f;
				int i = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Hunger>(), 0, npc.whoAmI);
				Main.npc[i].velocity.X = Main.rand.NextFloat(-0.4f, 0.4f);
				Main.npc[i].velocity.Y = Main.rand.NextFloat(-0.5f, -0.05f);
			}
		}
	}
}
