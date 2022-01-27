using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Tiles.Trees
{
	public class CreamTree : ModTree
	{
		private Mod mod => ModLoader.GetMod("TheConfectionRebirth");

		public override int GrowthFXGore() {
			return mod.GetGoreSlot("Gores/CreamTreeFX");
		}

		public override int DropWood() {
			return ModContent.ItemType<Items.Placeable.CreamWood>();
		}

		public override Texture2D GetTexture() {
			return mod.GetTexture("Tiles/Trees/CreamTree");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset) {
			return mod.GetTexture("Tiles/Trees/CreamTree_Tops");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame) {
			return mod.GetTexture("Tiles/Trees/CreamTree_Branches");
		}
	}
}