using TheConfectionRebirth.Items.Banners;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.NPCs
{
	public class CrookedCookie : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Crooked Cookie");  
		}

		public override void SetDefaults() {
			npc.width = 18;
			npc.height = 18;
			npc.damage = 60;
			npc.defense = 24;
			npc.lifeMax = 140;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath27;
			npc.noGravity = false;
			npc.noTileCollide = false;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 26;
			aiType = NPCID.Unicorn;
			banner = npc.type;
			bannerItem = ModContent.ItemType<CrookedCookieBanner>();
		}
		
		public override void HitEffect(int hitDirection, double damage) {
            if (npc.life <= 0) {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrookedCookieGore1"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrookedCookieGore2"));
            }
        }
		
		public override void AI()
		{
			npc.rotation += npc.velocity.X * 0.05f;
		}
	}	
}
