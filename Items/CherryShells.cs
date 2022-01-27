using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class CherryShells : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cherry Shells"); 
			Tooltip.SetDefault("'Surprisingly explosive'");
		}

		public override void SetDefaults() 
		{
			item.width = 10;
			item.height = 12;
			item.value = 7500;
			item.rare = 1;
			item.maxStack = 99;
		}
	}
}