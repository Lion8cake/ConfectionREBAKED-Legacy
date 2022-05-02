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
	
	public class Sprinkler : ModNPC
    {
	
		private Player player;
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sprinkler");
			Main.npcFrameCount[npc.type] = 2; 
		}
		
		public override void SetDefaults() {
			npc.width = 42;
			npc.height = 30;
			npc.damage = 70;
			npc.defense = 22;
			npc.lifeMax = 50;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath7;
			npc.noGravity = false;
			npc.knockBackResist = 0f;
			npc.aiStyle = 0;
			aiType = 0;
			animationType = NPCID.BlueSlime;
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.damage = (int)((float)npc.damage * 0.2f);
		}
		
		public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0) {
				Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
				NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, ModContent.NPCType<Sprinkling>());
			}
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
	     if(spawnInfo.player.ZoneOverworldHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection) 
		   return spawnInfo.player.ZoneOverworldHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection ? 1f : 0f;
		 return 0;
        }
		
		public override void AI()
		{
			Target();
			npc.ai[1] -= 1f;
			if (npc.ai[1] <= 0f)
			{
				Shoot();
			}
		}
		
		private void Target()
		{
			player = Main.player[npc.target];
		}
			
		private void Shoot()
		{
			int type = mod.ProjectileType("SprinklingBall");
			Vector2 velocity = player.Center - npc.Center;
			float magnitude = Magnitude(velocity);
			if (magnitude > 0f)
		    	{
				velocity *= 5f / magnitude;
			    }
			Projectile.NewProjectile(npc.Center, velocity, type, npc.damage, 2f);
			npc.ai[1] = 200f;
		}
		
		private float Magnitude(Vector2 mag)
		{
			return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
		}
	}
}