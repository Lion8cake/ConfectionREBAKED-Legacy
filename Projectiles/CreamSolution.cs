using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TheConfectionRebirth;
using TheConfectionRebirth.Tiles;
using TheConfectionRebirth.Walls;
using TheConfectionRebirth.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.World.Generation;

namespace TheConfectionRebirth.Projectiles
{
	public class CreamSolution : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Confection Spray");
		}

		public override void SetDefaults() {
			projectile.width = 6;
			projectile.height = 6;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.penetrate = -1;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

		public override void AI() {
			int dustType = ModContent.DustType<Dusts.CreamSolution>();

			if (projectile.owner == Main.myPlayer)
				Convert((int)(projectile.position.X + projectile.width / 2) / 16, (int)(projectile.position.Y + projectile.height / 2) / 16, 2);

			if (projectile.timeLeft > 133)
				projectile.timeLeft = 133;

			if (projectile.ai[0] > 7f) {
				float dustScale = 1f;

				if (projectile.ai[0] == 8f)
					dustScale = 0.2f;
				else if (projectile.ai[0] == 9f)
					dustScale = 0.4f;
				else if (projectile.ai[0] == 10f)
					dustScale = 0.6f;
				else if (projectile.ai[0] == 11f)
					dustScale = 0.8f;

				projectile.ai[0] += 1f;

				for (int i = 0; i < 1; i++) {
					int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustType, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100);
					Dust dust = Main.dust[dustIndex];
					dust.noGravity = true;
					dust.scale *= 1.75f;
					dust.velocity.X *= 2f;
					dust.velocity.Y *= 2f;
					dust.scale *= dustScale;
				}
			}
			else
				projectile.ai[0] += 1f;

			projectile.rotation += 0.3f * projectile.direction;
		}

		public void Convert(int i, int j, int size = 4) {
			for (int k = i - size; k <= i + size; k++) {
				for (int l = j - size; l <= j + size; l++) {
					if (WorldGen.InWorld(k, l, 1) && Math.Abs(k - i) + Math.Abs(l - j) < Math.Sqrt(size * size + size * size)) {
						int type = Main.tile[k, l].type;
						int wall = Main.tile[k, l].wall;

						if (WallID.Sets.Conversion.Stone[wall]) {
							Main.tile[k, l].wall = (ushort)ModContent.WallType<CreamstoneWall>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (WallID.Sets.Conversion.HardenedSand[wall]) {
							Main.tile[k, l].wall = (ushort)ModContent.WallType<HardenedCreamsandWall>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (WallID.Sets.Conversion.Sandstone[wall]) {
							Main.tile[k, l].wall = (ushort)ModContent.WallType<CreamsandstoneWall>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (WallID.Sets.Conversion.Grass[wall]) {
							Main.tile[k, l].wall = (ushort)ModContent.WallType<CreamGrassWall>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else
		                {
			               switch (wall)
			               {
			               case 40:
				           Main.tile[k, l].wall = (ushort)ModContent.WallType<CreamWall>();
				           WorldGen.SquareWallFrame(k, l);
				           NetMessage.SendTileSquare(-1, k, l, 1);
				           break;
						   case 2:
			               case 16:
			               case 59:
			               case 196:
			               case 197:
			               case 198:
		               	   case 199:
				           Main.tile[k, l].wall = (ushort)ModContent.WallType<CookieWall>();
				           WorldGen.SquareWallFrame(k, l);
				           NetMessage.SendTileSquare(-1, k, l, 1);
				           break;
						   case 71:
				           Main.tile[k, l].wall = (ushort)ModContent.WallType<BlueIceWall>();
				           WorldGen.SquareWallFrame(k, l);
				           NetMessage.SendTileSquare(-1, k, l, 1);
				           break;
						   case 73:
				           Main.tile[k, l].wall = (ushort)ModContent.WallType<PinkFairyFlossWall>();
				           WorldGen.SquareWallFrame(k, l);
				           NetMessage.SendTileSquare(-1, k, l, 1);
				           break;
						   }
						}
 
						if (TileID.Sets.Conversion.Stone[type]) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<Creamstone>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (TileID.Sets.Conversion.Sand[type]) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<Creamsand>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == TileID.Dirt) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<CookieBlock>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == 381) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<Creamstone>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == 179) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<Creamstone>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == 180) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<Creamstone>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == 181) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<Creamstone>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == 182) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<Creamstone>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == 183) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<Creamstone>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == TileID.SnowBlock) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<CreamBlock>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (TileID.Sets.Conversion.Grass[type]) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<CreamGrass>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (TileID.Sets.Conversion.Ice[type]) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<BlueIce>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (TileID.Sets.Conversion.Sandstone[type]) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<Creamsandstone>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (TileID.Sets.Conversion.HardenedSand[type]) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<HardenedCreamsand>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
					    else if (Main.tile[k, l].type == TileID.Ruby) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<CreamstoneRuby>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == TileID.Sapphire) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<CreamstoneSaphire>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == TileID.Diamond) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<CreamstoneDiamond>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == TileID.Emerald) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<CreamstoneEmerald>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == TileID.Amethyst) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<CreamstoneAmethyst>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == TileID.Topaz) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<CreamstoneTopaz>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == TileID.Cloud) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<PinkFairyFloss>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == TileID.RainCloud) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<PurpleFairyFloss>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						else if (Main.tile[k, l].type == TileID.SnowCloud) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<BlueFairyFloss>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
					    }
						Tile tile = Main.tile[k, l];
                      	switch (type)
                      	{
						case 165:
						{
							int topMost = ((tile.frameY > 54) ? l : ((tile.frameY % 36 == 0) ? l : (l - 1)));
							bool twoTall = tile.frameY <= 54;
							bool hanging = tile.frameY <= 18 || tile.frameY == 72;
							ushort newType2;
							if (tile.frameX >= 378 && tile.frameX <= 414)
							{
								newType2 = (ushort)ModContent.TileType<CreamstoneStalactite>();
							}
							else if ((tile.frameX >= 54 && tile.frameX <= 90) || (tile.frameX >= 216 && tile.frameX <= 360))
							{
								newType2 = (ushort)ModContent.TileType<CreamstoneStalactite>();
							}
							else
							{
								if (tile.frameX > 36)
								{
									break;
								}
								newType2 = (ushort)ModContent.TileType<BlueIceStalactite>();
							}
							if (Main.tile[k, topMost] != null)
							{
								Main.tile[k, topMost].type = newType2;
							}
							if (twoTall && Main.tile[k, topMost + 1] != null)
							{
								Main.tile[k, topMost + 1].type = newType2;
							}
							while (Main.tile[k, topMost].frameX >= 54)
							{
								if (Main.tile[k, topMost] != null)
								{
									Main.tile[k, topMost].frameX -= 54;
								}
								if (twoTall && Main.tile[k, topMost + 1] != null)
								{
									Main.tile[k, topMost + 1].frameX -= 54;
								}
							}
							if (Main.tile[k, topMost] != null)
							{
								WorldGen.SquareTileFrame(k, topMost);
								NetMessage.SendTileSquare(-1, k, topMost, 1);
							}
							if (Main.tile[k, topMost + 1] != null)
							{
								WorldGen.SquareTileFrame(k, topMost + 1);
								NetMessage.SendTileSquare(-1, k, topMost + 1, 1);
							}
							if (hanging)
							{
								Convert(k, topMost - 1);
							}
							else if (twoTall)
							{
								Convert(k, topMost + 2);
							}
							else
							{
								Convert(k, topMost + 1);
							}
							break;
						}
				}
			}
		}
	}
}
}
}
