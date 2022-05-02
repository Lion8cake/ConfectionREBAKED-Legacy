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
	public class CreamsandWitchPhase1 : ModNPC
	{
	
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Creamsand Witch");  
		}

		public override void SetDefaults() {
			npc.width = 40;
			npc.height = 40;
			npc.damage = 85;
			npc.defense = 15;
			npc.lifeMax = 1200;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 22;
			aiType = NPCID.FloatyGross;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
		 if(spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection && spawnInfo.player.ZoneDesert)
		   return spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection && spawnInfo.player.ZoneDesert ? .01f : 0f;
		 return 0;
        }
		
		public override void FindFrame(int frameHeight) {
			npc.spriteDirection = npc.direction;
		}
		
		public override void AI()
		{
			npc.ai[0] += 1f;
			if (Main.rand.NextBool(1000) && NPC.CountNPCS(ModContent.NPCType<CrookedCookie>()) < 25)
			{
				npc.ai[0] = 0f;
				int i = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<CrookedCookie>(), 0, npc.whoAmI);
				Main.npc[i].velocity.X = Main.rand.NextFloat(-0.4f, 0.4f);
				Main.npc[i].velocity.Y = Main.rand.NextFloat(-0.5f, -0.05f);
			}
			npc.ai[0] += 2f;
			if (Main.rand.NextBool(1000) && NPC.CountNPCS(ModContent.NPCType<MintJr>()) < 25)
			{
				npc.ai[0] = 0f;
				int i = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<MintJr>(), 0, npc.whoAmI);
				Main.npc[i].velocity.X = Main.rand.NextFloat(-0.4f, 0.4f);
				Main.npc[i].velocity.Y = Main.rand.NextFloat(-0.5f, -0.05f);
			}
		}
	
		public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0) {
				Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
				NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, ModContent.NPCType<CreamsandWitchPhase2>());
			}
		}
	}	
}
