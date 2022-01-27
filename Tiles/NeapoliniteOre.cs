using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Tiles
{
	public class NeapoliniteOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 680;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 975;
			Main.tileMergeDirt[Type] = true;
			Main.tileMerge[Type][(TileID.Stone)] = true;
			Main.tileMerge[Type][mod.TileType("Creamstone")] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			dustType = mod.DustType("NeapoliniteDust");

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Neapolinite Ore");
			AddMapEntry(new Color(153, 96, 62), name);

			drop = ModContent.ItemType<Items.Placeable.NeapoliniteOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 4f;
			minPick = 180;
		}
	}
}