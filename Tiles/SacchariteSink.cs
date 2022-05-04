using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Generation;
using System.Linq;
using Terraria.ModLoader.IO;
using TheConfectionRebirth.Dusts;

namespace TheConfectionRebirth.Tiles
{
	public class SacchariteSink : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 18 };
			TileObjectData.addTile(Type);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			adjTiles = new int[]{ 172 };
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Sink");
			dustType = ModContent.DustType<SacchariteCrystals>();
			disableSmartCursor = true;
			AddMapEntry(new Color(32, 174, 221), name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 32, mod.ItemType("SacchariteSink"));
		}
	}
}