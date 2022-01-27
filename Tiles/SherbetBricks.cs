using Microsoft.Xna.Framework;
using TheConfectionRebirth.Items.Placeable;
using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Tiles
{
  public class SherbetBricks : ModTile
  {
	public override void SetDefaults()
	{
		Main.tileSolid[Type] = true;
		Main.tileLighted[Type] = true;
		soundType = 2;
		animationFrameHeight = 90;
		Main.tileBlockLight[Type] = true;
		drop = ModContent.ItemType<Items.Placeable.SherbetBricks>();
		AddMapEntry(new Color(213, 105, 89));
		dustType = mod.DustType("SherbetDust");
	}

	public override void AnimateTile(ref int frame, ref int frameCounter)
	{
		frameCounter++;
		if (frameCounter > 5)
		{
			frameCounter = 0;
			frame++;
			if (frame > 12)
			{
				frame = 0;
			}
		}
	}

	public override void NumDust(int i, int j, bool fail, ref int num)
	{
		num = (fail ? 1 : 3);
	}

	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		r = 2f;
		g = 1f;
		b = 1f;
	}
  }
}
