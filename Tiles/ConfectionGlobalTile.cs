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
	public class ConfectionGlobalTile : GlobalTile
	{
		public static IList<ModWaterStyle> WaterStyles => (IList<ModWaterStyle>)typeof(WaterStyleLoader).GetField("waterStyles", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
	}
}