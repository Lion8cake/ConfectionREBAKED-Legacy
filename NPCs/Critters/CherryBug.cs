using TheConfectionRebirth.Items.Banners;
using TheConfectionRebirth.Dusts;
using Microsoft.Xna.Framework;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.NPCs.Critters
{
	internal class CherryBug : ModNPC
	{
		public override bool Autoload(ref string name) {
			return base.Autoload(ref name);
		}
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cherry Bug");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Firefly];
			Main.npcCatchable[npc.type] = true;
		}

		public override void SetDefaults() {
			npc.CloneDefaults(NPCID.Firefly);
			npc.catchItem = (short)ModContent.ItemType<CherryBugItem>();
			npc.aiStyle = 64;
			npc.friendly = true;
			aiType = NPCID.Firefly;
			animationType = NPCID.Firefly;
			banner = npc.type;
			bannerItem = ModContent.ItemType<CherryBugBanner>();
		}
		
		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<CritterBlood>());
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
		 if(spawnInfo.player.ZoneOverworldHeight && !Main.dayTime && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection)
		   return spawnInfo.player.ZoneOverworldHeight && !Main.dayTime && spawnInfo.player.GetModPlayer<ConfectionPlayer>().ZoneConfection ? 2f : 0f;
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

	internal class CherryBugItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cherry Bug");
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
			item.bait = 35;

			item.makeNPC = (short)ModContent.NPCType<CherryBug>();
		}
	}
}
