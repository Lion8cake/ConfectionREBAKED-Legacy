using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Tiles
{
	public class HallowedOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 680;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 975;
			Main.tileMergeDirt[Type] = true;
			Main.tileMerge[Type][mod.TileType("Creamstone")] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Hallowed Ore");
			AddMapEntry(new Color(180, 180, 204), name);

			dustType = 84;
			drop = ModContent.ItemType<Items.Placeable.HallowedOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 4f;
			minPick = 180;
		}
	}
}