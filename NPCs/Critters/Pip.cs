using TheConfectionRebirth.Items.Banners;
using Microsoft.Xna.Framework;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.NPCs.Critters
{
	internal class Pip : ModNPC
	{
		public override bool Autoload(ref string name) {
			return base.Autoload(ref name);
		}
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pip");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Bird];
			Main.npcCatchable[npc.type] = true;
		}

		public override void SetDefaults() {
			npc.CloneDefaults(NPCID.Bird);
			npc.catchItem = (short)ModContent.ItemType<PipItem>();
			npc.aiStyle = 24;
			npc.friendly = true;
			aiType = NPCID.Bird;
			animationType = NPCID.Bird;
			banner = npc.type;
			bannerItem = ModContent.ItemType<PipBanner>();
		}
		
		public override void HitEffect(int hitDirection, double damage) {
            if (npc.life <= 0) {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PipGore"));
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

        //Might add gore later

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

	internal class PipItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pip");
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

			item.makeNPC = (short)ModContent.NPCType<Pip>();
		}
	}
}
