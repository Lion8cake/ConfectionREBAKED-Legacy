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
	public class Iscreamer : ModNPC
	{

		public bool attacking;
	
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Iscreamer");  
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.width = 60;
			npc.height = 60;
			npc.damage = 50;
			npc.defense = 22;
			npc.lifeMax = 400;
			npc.HitSound = SoundID.NPCHit36;
			npc.DeathSound = SoundID.NPCDeath39;
			npc.value = 600f;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 22;
			aiType = NPCID.FloatyGross;
			banner = npc.type;
			bannerItem = ModContent.ItemType<IscreamerBanner>();
		}
		
		public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, 13);
				Gore.NewGore(npc.position, npc.velocity, 12);
				Gore.NewGore(npc.position, npc.velocity, 11);
			}
		}
		
		int speed = 10;
        int maxFrames = 3;
        int frame;
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            if (npc.frameCounter >= speed)
            {
                frame++;
                npc.frameCounter = 0;
            }

            if (frame > maxFrames)
                frame = 0;
            
            npc.frame.Y = frame * frameHeight;
            npc.spriteDirection = npc.direction;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
		 if(spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection && !spawnInfo.player.ZoneSnow)
		   return spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection && !spawnInfo.player.ZoneSnow ? .2f : 0f;
		 return 0;
        }
		
		public override void AI()
		{
			Lighting.AddLight(npc.position, 0.1f, 0.1f, 0.3f);
			npc.TargetClosest();
			Player player = Main.player[npc.target];
			Vector2 val = Main.player[npc.target].Center + new Vector2(npc.Center.X, npc.Center.Y);
			Vector2 val2 = npc.Center + new Vector2(npc.Center.X, npc.Center.Y);
			npc.netUpdate = true;
			if (player.position.X > npc.position.X)
			{
				npc.spriteDirection = 1;
			}
			else if (player.position.X < npc.position.X)
			{
				npc.spriteDirection = -1;
			}
			npc.TargetClosest();
			npc.velocity.X = npc.velocity.X * 0.93f;
			if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
			{
				npc.velocity.X = 0f;
			}
			if (npc.ai[0] == 0f)
			{
				npc.ai[0] = 500f;
			}
			if (npc.ai[2] != 0f && npc.ai[3] != 0f)
			{
				Main.PlaySound(SoundID.Item8, npc.position);
				for (int i = 0; i < 50; i++)
				{
					int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 92, 0f, 0f, 100, default(Color), 1.8f);
					Dust obj = Main.dust[num];
					obj.velocity *= 3f;
					Main.dust[num].noGravity = true;
				}
				npc.position.X = npc.ai[2] * 16f - (float)(npc.width / 2) + 8f;
				npc.position.Y = npc.ai[3] * 16f - (float)npc.height;
				npc.velocity.X = 0f;
				npc.velocity.Y = 0f;
				npc.ai[2] = 0f;
				npc.ai[3] = 0f;
				Main.PlaySound(SoundID.Item8, npc.position);
				for (int j = 0; j < 50; j++)
				{
					int num2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 92, 0f, 0f, 100, default(Color), 1.8f);
					Dust obj2 = Main.dust[num2];
					obj2.velocity *= 3f;
					Main.dust[num2].noGravity = true;
				}
			}
			npc.ai[0] += 1f;
			npc.netUpdate = true;
			if (npc.ai[0] >= 650f && Main.netMode != 1)
			{
				npc.ai[0] = 1f;
				int num3 = (int)Main.player[npc.target].position.X / 16;
				int num4 = (int)Main.player[npc.target].position.Y / 16;
				int num5 = (int)npc.position.X / 16;
				int num6 = (int)npc.position.Y / 16;
				int num7 = 20;
				int num8 = 0;
				bool flag = false;
				if (Math.Abs(npc.position.X - Main.player[npc.target].position.X) + Math.Abs(npc.position.Y - Main.player[npc.target].position.Y) > 2000f)
				{
					num8 = 100;
					flag = true;
				}
				while (!flag && num8 < 100)
				{
					num8++;
					int num9 = Main.rand.Next(num3 - num7, num3 + num7);
					for (int k = Main.rand.Next(num4 - num7, num4 + num7); k < num4 + num7; k++)
					{
						if ((k < num4 - 4 || k > num4 + 4 || num9 < num3 - 4 || num9 > num3 + 4) && (k < num6 - 1 || k > num6 + 1 || num9 < num5 - 1 || num9 > num5 + 1) && Main.tile[num9, k].nactive())
						{
							bool flag2 = true;
							if (Main.tile[num9, k - 1].lava())
							{
								flag2 = false;
							}
							if (flag2 && Main.tileSolid[Main.tile[num9, k].type] && !Collision.SolidTiles(num9 - 1, num9 + 1, k - 4, k - 1))
							{
								npc.ai[2] = num9;
								npc.ai[3] = k;
								flag = true;
								break;
							}
						}
					}
				}
				npc.netUpdate = true;
			}
			npc.netUpdate = true;
		}
	}
}
