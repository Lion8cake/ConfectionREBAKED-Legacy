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
	
	public class Hunger : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Hunger");
			Main.npcFrameCount[npc.type] = 6; 
		}
		
		public override void SetDefaults() {
			npc.width = 20;
			npc.height = 20;
			npc.damage = 80;
			npc.defense = 22;
			npc.lifeMax = 500;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 25;
			aiType = NPCID.PresentMimic;
			animationType = NPCID.PresentMimic;
			banner = npc.type;
			bannerItem = ModContent.ItemType<HungerBanner>();
		}
		
		public override void HitEffect(int hitDirection, double damage) {
            if (npc.life <= 0) {
			Gore.NewGore(npc.position, npc.velocity, 13);
			Gore.NewGore(npc.position, npc.velocity, 12);
			Gore.NewGore(npc.position, npc.velocity, 11);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HungerGore"));
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HungerGore"));
            }
        }
	}
}