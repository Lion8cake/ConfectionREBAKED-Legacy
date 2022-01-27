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
	public class MintJr : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mint Jr");  
		}

		public override void SetDefaults() {
			npc.width = 18;
			npc.height = 18;
			npc.damage = 60;
			npc.defense = 20;
			npc.lifeMax = 120;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 5;
			aiType = NPCID.MeteorHead;
			banner = npc.type;
			bannerItem = ModContent.ItemType<MintJrBanner>();
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
