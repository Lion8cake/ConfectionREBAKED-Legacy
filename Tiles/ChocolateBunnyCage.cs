using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheConfectionRebirth.Tiles
{
	class ChocolateBunnyCage : ModTile
	{
		public override void SetDefaults() {
			Main.tileLighted[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.tileFrameImportant[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 18 };
			TileObjectData.addTile(Type);

			animationFrameHeight = 54;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Chocolate Bunny Cage");
			AddMapEntry(new Color(122, 217, 232), name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(i * 16, j * 16, 48, 32, ModContent.ItemType<ChocolateBunnyCageItem>());
		}

		public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset) {
			Tile tile = Main.tile[i, j];
			Main.critterCage = true;
			int left = i - tile.frameX / 18;
			int top = j - tile.frameY / 18;
			int offset = left / 3 * (top / 3);
			offset %= Main.cageFrames;
			frameYOffset = Main.bunnyCageFrame[offset] * animationFrameHeight;
		}
	}

	internal class ChocolateBunnyCageItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Chocolate Bunny Cage");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.BunnyCage);
			item.createTile = ModContent.TileType<ChocolateBunnyCage>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Terrarium);
			recipe.AddIngredient(ModContent.ItemType<NPCs.Critters.ChocolateBunnyItem>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
