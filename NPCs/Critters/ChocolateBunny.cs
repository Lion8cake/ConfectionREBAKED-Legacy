using TheConfectionRebirth.Items.Banners;
using Microsoft.Xna.Framework;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.NPCs.Critters
{
	internal class ChocolateBunny : ModNPC
	{
		public override bool Autoload(ref string name) {
			return base.Autoload(ref name);
		}
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Chocolate Bunny");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Bunny];
			Main.npcCatchable[npc.type] = true;
		}

		public override void SetDefaults() {
			npc.CloneDefaults(NPCID.Bunny);
			npc.catchItem = (short)ModContent.ItemType<ChocolateBunnyItem>();
			npc.aiStyle = 7;
			npc.friendly = true;
			aiType = NPCID.Bunny;
			animationType = NPCID.Bunny;
			banner = npc.type;
			bannerItem = ModContent.ItemType<ChocolateBunnyBanner>();
		}
		
		public override void HitEffect(int hitDirection, double damage) {
            if (npc.life <= 0) {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ChocolateBunnyGore1"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ChocolateBunnyGore2"));
            }
        }

		public override bool? CanBeHitByItem(Player player, Item item) {
			return true;
		}

		public override bool? CanBeHitByProjectile(Projectile projectile) {
			return true;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
		 if(spawnInfo.player.ZoneOverworldHeight && Main.dayTime && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection && !spawnInfo.player.ZoneDesert)
		   return spawnInfo.player.ZoneOverworldHeight && Main.dayTime && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection && !spawnInfo.player.ZoneDesert ? 1f : 0f;
		 return 0;
        }

		public override void OnCatchNPC(Player player, Item item) {
			item.stack = 1;

			try {
				var npcCenter = npc.Center.ToTileCoordinates();
			}
			catch {
				return;
			}
		}

	}

	internal class ChocolateBunnyItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Chocolate Bunny");
		}

		public override void SetDefaults() {
			item.useStyle = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 999;
			item.consumable = true;
			item.width = 12;
			item.height = 12;
			item.makeNPC = 360;
			item.noUseGraphic = true;

			item.makeNPC = (short)ModContent.NPCType<ChocolateBunny>();
		}
	}
}
