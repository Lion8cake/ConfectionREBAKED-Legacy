using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Backgrounds
{
	public class ConfectionSnowUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle() {
			return !Main.gameMenu && Main.LocalPlayer.GetModPlayer<ConfectionPlayer>().ZoneConfection && Main.LocalPlayer.ZoneSnow;
		}

		public override void FillTextureArray(int[] textureSlots) {
		    textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/ConfectionSnowUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/ConfectionSnowUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/ConfectionSnowUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/ConfectionSnowUG3");
		}
	}
}