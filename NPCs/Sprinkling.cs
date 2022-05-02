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
	
	public class Sprinkling : ModNPC
    {
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sprinkling");
			Main.npcFrameCount[npc.type] = 10; 
		}
		
		public override void SetDefaults() {
			npc.width = 36;
			npc.height = 36;
			npc.damage = 75;
			npc.defense = 20;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath7;
			npc.value = 350f;
			npc.noGravity = true;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 22;
			aiType = NPCID.Pixie;
			animationType = NPCID.Pixie;
			banner = npc.type;
			bannerItem = ModContent.ItemType<SprinklingBanner>();
		}
		
		public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, 13);
				Gore.NewGore(npc.position, npc.velocity, 12);
				Gore.NewGore(npc.position, npc.velocity, 11);
			}
		}
	}
}