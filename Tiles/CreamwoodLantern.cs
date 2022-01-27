using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheConfectionRebirth.Tiles
{
	class CreamwoodLantern : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;;
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Lantern");
			disableSmartCursor = true;
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			AddMapEntry(new Color(106, 65, 51), name);
		}
		
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 48, mod.ItemType("CreamwoodLantern"));
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			Tile tile = Main.tile[i, j];
			if (tile.frameX < 88)
			{
				r = 2f;
				g = 1f;
				b = 1f;
			}
		}
		
		public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
		{
			offsetY = -2;
		}
		
		public override void PostDraw(int i, int j, SpriteBatch spriteBatch) {
			SpriteEffects effects = SpriteEffects.None;
			if (i % 2 == 1) {
				effects = SpriteEffects.FlipHorizontally;
			}

			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			if (Main.drawToScreen) {
				zero = Vector2.Zero;
			}

			Tile tile = Main.tile[i, j];
			int width = 16;
			int offsetY = 0;
			int height = 16;
			TileLoader.SetDrawPositions(i, j, ref width, ref offsetY, ref height);
			var flameTexture = mod.GetTexture("Tiles/CreamwoodLantern_flame"); 

			ulong num190 = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i);
			for (int c = 0; c < 7; c++) {
				float shakeX = Utils.RandomInt(ref num190, -10, 11) * 0.15f;
				float shakeY = Utils.RandomInt(ref num190, -10, 1) * 0.35f;
				Main.spriteBatch.Draw(flameTexture, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(tile.frameX, tile.frameY, width, height), new Color(100, 100, 100, 0), 0f, default(Vector2), 1f, effects, 0f);
			}
		}
	}
}