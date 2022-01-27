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
	public class BirthdayCookie : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Birthday Cookie");  
		}

		public override void SetDefaults() {
			npc.width = 44;
			npc.height = 44;
			npc.damage = 58;
			npc.defense = 17;
			npc.lifeMax = 360;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath27;
			npc.value = 10000f;
			npc.noGravity = false;
			npc.noTileCollide = false;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 26;
			aiType = NPCID.Unicorn;
			banner = npc.type;
			bannerItem = ModContent.ItemType<RollerCookieBanner>();
		}
		
		public override void HitEffect(int hitDirection, double damage) {
            if (npc.life <= 0) {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BirthdayCookieGore"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BirthdayCookieGore"));
            }
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
		 if(spawnInfo.player.ZoneOverworldHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection)
		   return spawnInfo.player.ZoneOverworldHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection ? .01f : 0f;
		 return 0;
        }
		
		public override void AI()
		{
			npc.rotation += npc.velocity.X * 0.05f;
		}
     }	
}
