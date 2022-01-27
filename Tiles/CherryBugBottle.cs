using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheConfectionRebirth.Tiles
{
	internal class CherryBugBottle : ModTile
	{
		public override void SetDefaults() {
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Cherry Bug in a Bottle");
			AddMapEntry(new Color(60, 26, 44), name);
		}

		private readonly int animationFrameWidth = 18;

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			r = 0.93f;
			g = 0.11f;
			b = 0.42f;
		}

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects) {
			if (i % 2 == 1) {
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}

		public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset) {
			int uniqueAnimationFrame = Main.tileFrame[Type] + i;
			if (i % 2 == 0) {
				uniqueAnimationFrame += 3;
			}
			if (i % 3 == 0) {
				uniqueAnimationFrame += 3;
			}
			if (i % 4 == 0) {
				uniqueAnimationFrame += 3;
			}
			uniqueAnimationFrame = uniqueAnimationFrame % 6;

			frameXOffset = uniqueAnimationFrame * animationFrameWidth;
		}

		public override void AnimateTile(ref int frame, ref int frameCounter) {
		
		frame = Main.tileFrame[TileID.FireflyinaBottle];
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(i * 16, j * 16, 16, 32, ModContent.ItemType<CherryBugBottleItem>());
		}
	}

	internal class CherryBugBottleItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cherry Bug in a Bottle");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.FireflyinaBottle);
			item.createTile = ModContent.TileType<CherryBugBottle>();
		}
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bottle);
			recipe.AddIngredient(ModContent.ItemType<NPCs.Critters.CherryBugItem>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
