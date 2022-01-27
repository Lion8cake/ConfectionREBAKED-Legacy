using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Backgrounds
{
	public class ConfectionUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle() {
			return Main.LocalPlayer.GetModPlayer<ConfectionPlayer>().ZoneConfection && !Main.LocalPlayer.ZoneSnow;
		}

		public override void FillTextureArray(int[] textureSlots) {
		    textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/ConfectionUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/ConfectionUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/ConfectionUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/ConfectionUG3");
		}
	}
}