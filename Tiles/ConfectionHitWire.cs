using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace TheConfectionRebirth.Tiles
{
    public class ConfectionHitWire
    {
        public static void HitWire(int type, int i, int j, int tileX, int tileY)
        {
	        int x = i - Main.tile[i, j].frameX / 18 % tileX;
	        int y = j - Main.tile[i, j].frameY / 18 % tileY;
        	for (int m = x; m < x + tileX; m++)
        	{
        		for (int n = y; n < y + tileY; n++)
        		{
        			if (Main.tile[m, n] == null)
        			{
        				Main.tile[m, n] = new Tile();
        			}
        			if (Main.tile[m, n].active() && Main.tile[m, n].type == type)
        			{
        				if (Main.tile[m, n].frameX < 18 * tileX)
        				{
        					Main.tile[m, n].frameX += (short)(18 * tileX);
        				}
        				else
        				{
        					Main.tile[m, n].frameX -= (short)(18 * tileX);
        				}
        			}
        		}
        	}
        	if (!Wiring.running)
        	{
        		return;
        	}
        	for (int k = 0; k < tileX; k++)
        	{
        		for (int l = 0; l < tileY; l++)
        		{
        			Wiring.SkipWire(x + k, y + l);
        		}
        	}
        }
    }
}