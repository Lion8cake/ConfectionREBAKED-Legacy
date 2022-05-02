using TheConfectionRebirth.Items.Banners;
using TheConfectionRebirth.Gores;
using System;
using System.IO;
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
	internal class GummyWyrmMini1Head : ConfectionWormMini
	{

		public override string Texture => "TheConfectionRebirth/NPCs/GummyWyrmHead";

        public override void SetDefaults()
        {
            npc.width = 10;
			npc.height = 10;
			npc.damage = 70;
			npc.defense = 24;
			npc.lifeMax = 250;
			npc.netAlways = true;
            npc.scale = 1f;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.aiStyle = -1;
            npc.behindTiles = true;
            npc.value = 500f;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.GummyWyrmBanner>();
        }

        public override void Init()
        {
            base.Init();
            head = true;
        }
    }

    internal class GummyWyrmMini1Body : ConfectionWormMini
    {
        public override string Texture => "TheConfectionRebirth/NPCs/GummyWyrmBody";

        public override void SetDefaults()
        {
            npc.width = 10;
			npc.height = 10;
			npc.damage = 70;
			npc.defense = 34;
			npc.lifeMax = 250;
            npc.netAlways = true;
            npc.scale = 1f;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.aiStyle = -1;
            npc.behindTiles = true;
            npc.value = 500f;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.GummyWyrmBanner>();
        }
    }

    internal class GummyWyrmMini1Tail : ConfectionWormMini
    {
        public override string Texture => "TheConfectionRebirth/NPCs/GummyWyrmTail";

        public override void SetDefaults()
        {			
			npc.width = 10;
			npc.height = 10;
			npc.damage = 70;
			npc.defense = 44;
			npc.lifeMax = 250;
            npc.netAlways = true;
            npc.scale = 1f;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.aiStyle = -1;
            npc.behindTiles = true;
            npc.value = 500f;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.GummyWyrmBanner>();
        }

		public override void Init()
        {
            base.Init();
            tail = true;
        }
    }

    public abstract class ConfectionWormMini : Worm
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gummy Wyrm");
        }

        public override void Init()
        {
            minLength = 6;
            maxLength = 8;
            tailType = ModContent.NPCType<GummyWyrmMini1Tail>();
            bodyType = ModContent.NPCType<GummyWyrmMini1Body>();
            headType = ModContent.NPCType<GummyWyrmMini1Head>();
            speed = 8.5f;
            turnSpeed = 0.07f;
        }
    }
}