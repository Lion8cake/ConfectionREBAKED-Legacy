using TheConfectionRebirth.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Waters
{
	public class CreamWaterStyle : ModWaterStyle
	{
		public override bool ChooseWaterStyle()
			=> Main.bgStyle == mod.GetSurfaceBgStyleSlot("ConfectionSurfaceBgStyle");

		public override int ChooseWaterfallStyle() 
			=> mod.GetWaterfallStyleSlot("CreamWaterfallStyle");

		public override int GetSplashDust() 
			=> ModContent.DustType<CreamWaterSplash>();

		public override int GetDropletGore() 
			=> mod.GetGoreSlot("Gores/CreamDroplet");

		public override void LightColorMultiplier(ref float r, ref float g, ref float b) {
			r = 1f;
			g = 1f;
			b = 1f;
		}

		public override Color BiomeHairColor() 
			=> Color.White;
	}
}