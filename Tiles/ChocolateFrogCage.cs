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
	class ChocolateFrogCage : ModTile
	{
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
			TileObjectData.addTile(Type);

			animationFrameHeight = 36;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Chocolate Frog Cage");
			AddMapEntry(new Color(122, 217, 232), name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(i * 16, j * 16, 48, 32, ModContent.ItemType<ChocolateFrogCageItem>());
		}

		public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset) {
			Tile tile = Main.tile[i, j];
			Main.critterCage = true;
			int left = i - tile.frameX / 18;
			int top = j - tile.frameY / 18;
			int offset = left / 3 * (top / 3);
			offset %= Main.cageFrames;
			frameYOffset = Main.frogCageFrame[offset] * animationFrameHeight;
		}
	}

	internal class ChocolateFrogCageItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Chocolate Frog Cage");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.FrogCage);
			item.createTile = ModContent.TileType<ChocolateFrogCage>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Terrarium);
			recipe.AddIngredient(ModContent.ItemType<NPCs.Critters.ChocolateFrogItem>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
