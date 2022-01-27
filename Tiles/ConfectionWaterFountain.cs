using System.Linq;
using TheConfectionRebirth;
using TheConfectionRebirth.Items.Placeable;
using TheConfectionRebirth.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ObjectData;
using System;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;

namespace TheConfectionRebirth.Tiles
{
public class ConfectionWaterFountain : ModTile
{
	public override void SetDefaults()
	{
	    Main.tileLighted[Type] = true;
    	Main.tileFrameImportant[Type] = true;
    	Main.tileLavaDeath[Type] = false;
        Main.tileWaterDeath[Type] = false;
     	TileObjectData.newTile.LavaDeath = false;
    	TileObjectData.addTile(Type);
    	TileID.Sets.HasOutlines[Type] = true;
    	TileObjectData.newTile.Width = 2;
    	TileObjectData.newTile.Height = 4;
    	TileObjectData.newTile.CoordinateHeights = new int[4] { 16, 16, 16, 16 };
    	TileObjectData.newTile.CoordinateWidth = 16;
     	TileObjectData.newTile.CoordinatePadding = 2;
	    TileObjectData.newTile.Origin = new Point16(0, 3);
	    TileObjectData.newTile.UsesCustomCanPlace = true;
    	TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop, 2, 0);
    	TileObjectData.addTile(Type);
		animationFrameHeight = 72;
		AddMapEntry(new Color(188, 168, 120));
	}

	public override void NearbyEffects(int i, int j, bool closer)
	{
		if (Main.tile[i, j].frameX < 36 && ConfectionGlobalTile.WaterStyles.Any((ModWaterStyle style) => style.Name == "CreamWaterStyle"))
		{
			Main.fountainColor = ConfectionGlobalTile.WaterStyles.FirstOrDefault((ModWaterStyle style) => style.Name == "CreamWaterStyle").Type;
		}
	}

	public override bool HasSmartInteract()
	{
		return true;
	}

	public override void NumDust(int i, int j, bool fail, ref int num)
	{
		num = (fail ? 1 : 3);
	}

	public override void AnimateTile(ref int frame, ref int frameCounter)
	{
		frameCounter++;
		if (frameCounter >= 6)
		{
			frame = (frame + 1) % 4;
			frameCounter = 0;
		}
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		Item.NewItem(i * 16, j * 16, 16, 32, mod.ItemType("ConfectionWaterFountain"));
	}
	
	public override void HitWire(int i, int j)
	{
		ConfectionHitWire.HitWire(Type, i, j, 2, 4);
	}

	public override bool NewRightClick(int i, int j)
	{
		ConfectionHitWire.HitWire(Type, i, j, 2, 4);
		return true;
	}
	
	public override void MouseOver(int i, int j) {
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.showItemIcon = true;
		player.showItemIcon2 = ModContent.ItemType<Items.Placeable.ConfectionWaterFountain>();
	}
}
}