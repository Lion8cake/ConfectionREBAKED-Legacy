using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Tiles.Trees
{
	public class CreamPalmTree : ModPalmTree
	{
		public override Texture2D GetTexture() => ModContent.GetTexture("TheConfectionRebirth/Tiles/Trees/CreamPalmTree");
		
		public override Texture2D GetTopTextures() => ModContent.GetTexture("TheConfectionRebirth/Tiles/Trees/CreamPalmTree_Tops");

        public override int DropWood() {
			return ModContent.ItemType<Items.Placeable.CreamWood>();
		}		
	}
}