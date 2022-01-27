using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class CanofMeat : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Can of Meat"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("'Sometimes carried by creatures in the bloody desert'");
		}

		public override void SetDefaults() 
		{
			item.width = 10;
			item.height = 12;
			item.value = 4500;
			item.rare = ItemRarityID.Green;
			item.maxStack = 99;
		}
	}
}