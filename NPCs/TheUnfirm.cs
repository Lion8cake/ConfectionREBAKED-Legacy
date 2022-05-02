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
	public class TheUnfirm : ModNPC //If anyone wants to animate it or make actually good ai for it, GO FOR IT!!!
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("The Unfirm");
			Main.npcFrameCount[npc.type] = 8;
		}

		public override void SetDefaults() {
			npc.width = 100;
			npc.height = 100;
			npc.damage = 90;
			npc.defense = 25;
			npc.lifeMax = 5000;
			npc.HitSound = SoundID.NPCHit21;
			npc.DeathSound = SoundID.NPCDeath23;
			npc.value = 50000f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = 494;
	    	animationType = 494;
			banner = npc.type;
			bannerItem = ModContent.ItemType<TheUnfirmBanner>();
		}
		
		public override void HitEffect(int hitDirection, double damage) {
            if (npc.life <= 0) {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UnfirmGore1"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UnfirmGore2"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UnfirmGore1"));
            }
        }
	}
}
