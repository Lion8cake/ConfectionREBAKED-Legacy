using TheConfectionRebirth.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Waters
{
	public class CreamWaterStyleSand : ModWaterStyle
	{
		public override bool ChooseWaterStyle()
			=> Main.bgStyle == mod.GetSurfaceBgStyleSlot("ConfectionSandSurfaceBgStyle");

		public override int ChooseWaterfallStyle() 
			=> mod.GetWaterfallStyleSlot("CreamWaterfallStyleSand");

		public override int GetSplashDust() 
			=> ModContent.DustType<CreamWaterSplashSand>();

		public override int GetDropletGore() 
			=> mod.GetGoreSlot("Gores/CreamDropletSand");

		public override void LightColorMultiplier(ref float r, ref float g, ref float b) {
			r = 1f;
			g = 1f;
			b = 1f;
		}

		public override Color BiomeHairColor() 
			=> Color.White;
	}
}