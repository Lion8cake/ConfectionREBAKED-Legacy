using TheConfectionRebirth.Dusts;
using TheConfectionRebirth.Items.Placeable;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Achievements;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheConfectionRebirth.Tiles
{
	public class ConfectionBiomeChestTile : ModTile
	{
		public override void SetDefaults() {
			Main.tileSpelunker[Type] = true;
			Main.tileContainer[Type] = true;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1200;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileValue[Type] = 500;
			TileID.Sets.HasOutlines[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileObjectData.newTile.HookCheck = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.AfterPlacement_Hook), -1, 0, false);
			TileObjectData.newTile.AnchorInvalidTiles = new[] { 127 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Confection Chest");
			AddMapEntry(new Color(200, 200, 200), name, MapChestName);
			name = CreateMapEntryName(Name + "_Locked");
			name.SetDefault("Locked Confection Chest");
			AddMapEntry(new Color(36, 138, 41), name, MapChestName);
			dustType = ModContent.DustType<CreamwoodDust>();
			disableSmartCursor = true;
			adjTiles = new int[] { TileID.Containers };
			chest = "Confection Chest";
			chestDrop = ModContent.ItemType<Items.Placeable.ConfectionBiomeChestItem>();
		}

		public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].frameX / 36);

		public override bool HasSmartInteract() => true;

		public override bool IsLockedChest(int i, int j) => Main.tile[i, j].frameX / 36 == 1;

		public override bool UnlockChest(int i, int j, ref short frameXAdjustment, ref int dustType, ref bool manual) {
			if (NPC.downedPlantBoss)
			    AchievementsHelper.NotifyProgressionEvent(20);
				return true;
			dustType = this.dustType;
			return false;
		}

		public string MapChestName(string name, int i, int j) {
			int left = i;
			int top = j;
			Tile tile = Main.tile[i, j];
			if (tile.frameX % 36 != 0) {
				left--;
			}
			if (tile.frameY != 0) {
				top--;
			}
			int chest = Chest.FindChest(left, top);
			if (chest < 0) {
				return Language.GetTextValue("LegacyChestType.0");
			}
			else if (Main.chest[chest].name == "") {
				return name;
			}
			else {
				return name + ": " + Main.chest[chest].name;
			}
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = 1;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(i * 16, j * 16, 32, 32, chestDrop);
			Chest.DestroyChest(i, j);
		}

		public override bool NewRightClick(int i, int j) {
		Player localPlayer = Main.LocalPlayer;
		Tile tile = Main.tile[i, j];
		Main.mouseRightRelease = false;
		int num = i;
		int num2 = j;
		if (tile.frameX % 36 != 0)
		{
			num--;
		}
		if (tile.frameY != 0)
		{
			num2--;
		}
		if (localPlayer.sign >= 0)
		{
			Main.PlaySound(11);
			localPlayer.sign = -1;
			Main.editSign = false;
			Main.npcChatText = "";
		}
		if (Main.editChest)
		{
			Main.PlaySound(12);
			Main.editChest = false;
			Main.npcChatText = "";
		}
		if (localPlayer.editedChestName)
		{
			NetMessage.SendData(33, -1, -1, NetworkText.FromLiteral(Main.chest[localPlayer.chest].name), localPlayer.chest, 1f);
			localPlayer.editedChestName = false;
		}
		bool flag = IsLockedChest(num, num2);
		if (Main.netMode == 1 && !flag)
		{
			if (num == localPlayer.chestX && num2 == localPlayer.chestY && localPlayer.chest >= 0)
			{
				localPlayer.chest = -1;
				Recipe.FindRecipes();
				Main.PlaySound(11);
			}
			else
			{
				NetMessage.SendData(31, -1, -1, null, num, num2);
				Main.stackSplit = 600;
			}
		}
		else if (flag)
		{
			int num3 = base.mod.ItemType("ConfectionBiomeKey");
			for (int k = 0; k < 58; k++)
			{
				if (localPlayer.inventory[k].type == num3 && localPlayer.inventory[k].stack > 0 && Chest.Unlock(num, num2))
				{
					localPlayer.inventory[k].stack--;
					if (localPlayer.inventory[k].stack <= 0)
					{
						localPlayer.inventory[k].TurnToAir();
					}
					if (Main.netMode == 1)
					{
						NetMessage.SendData(52, -1, -1, null, localPlayer.whoAmI, 1f, num, num2);
					}
					break;
				}
			}
		}
		else
		{
			int num4 = Chest.FindChest(num, num2);
			if (num4 >= 0)
			{
				Main.stackSplit = 600;
				if (num4 == localPlayer.chest)
				{
					localPlayer.chest = -1;
					Main.PlaySound(11);
				}
				else
				{
					localPlayer.chest = num4;
					Main.playerInventory = true;
					if (PlayerInput.GrappleAndInteractAreShared)
					{
						PlayerInput.Triggers.JustPressed.Grapple = false;
					}
					Main.recBigList = false;
					localPlayer.chestX = num;
					localPlayer.chestY = num2;
					Main.PlaySound((localPlayer.chest < 0) ? 10 : 12);
				}
				Recipe.FindRecipes();
			}
		}
		return true;
 	}

		public override void MouseOver(int i, int j) {
			Player player = Main.LocalPlayer;
			Tile tile = Main.tile[i, j];
			int left = i;
			int top = j;
			if (tile.frameX % 36 != 0) {
				left--;
			}
			if (tile.frameY != 0) {
				top--;
			}
			int chest = Chest.FindChest(left, top);
			player.showItemIcon2 = -1;
			if (chest < 0) {
				player.showItemIconText = Language.GetTextValue("LegacyChestType.0");
			}
			else {
				player.showItemIconText = Main.chest[chest].name.Length > 0 ? Main.chest[chest].name : "Confection Chest";
				if (player.showItemIconText == "Confection Chest") {
					player.showItemIcon2 = ModContent.ItemType<Items.Placeable.ConfectionBiomeChestItem>();
					if (Main.tile[left, top].frameX / 36 == 1)
						player.showItemIcon2 = ModContent.ItemType<Items.ConfectionBiomeKey>();
					player.showItemIconText = "";
				}
			}
			player.noThrow = 2;
			player.showItemIcon = true;
		}

		public override void MouseOverFar(int i, int j) {
			MouseOver(i, j);
			Player player = Main.LocalPlayer;
			if (player.showItemIconText == "") {
				player.showItemIcon = false;
				player.showItemIcon2 = 0;
			}
		}
	}
}