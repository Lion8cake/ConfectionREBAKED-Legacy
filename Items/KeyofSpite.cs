using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class KeyofSpite : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Key of Spite");
			Tooltip.SetDefault("'Charged with the essence of many souls'");
		}

		public override void SetDefaults() 
		{
			item.width = 10;
			item.height = 12;
			item.maxStack = 99;
		}
	}
}