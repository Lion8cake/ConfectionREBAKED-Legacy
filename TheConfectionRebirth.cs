using TheConfectionRebirth.Items;
using TheConfectionRebirth.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace TheConfectionRebirth
{
	public class TheConfectionRebirth : Mod
	{
		public static Mod mod;
        public override void Load()
        {
			mod = this;
			IL.Terraria.Main.DrawMenu += Hooks.ConfectionWorldCreationUI.ILDrawMenu;
            if (!Main.dedServ)
            {
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Confection"), ItemType("ConfectionMusicBox"), TileType("ConfectionMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/ConfectionUnderground"), ItemType("ConfectionUGMusicBox"), TileType("ConfectionUGMusicBox"));
            }
        }
		
		public override void UpdateMusic(ref int music, ref MusicPriority priority) {
			if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active) {
				return;
			}
			if (Main.LocalPlayer.GetModPlayer<ConfectionPlayer>().ZoneConfection) {
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/Confection");
				priority = MusicPriority.BiomeLow;
			}
			if(Main.LocalPlayer.ZoneRockLayerHeight && Main.LocalPlayer.GetModPlayer<ConfectionPlayer>().ZoneConfection) {
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/ConfectionUnderground");
				priority = MusicPriority.BiomeLow;
			}
		}
	}
}