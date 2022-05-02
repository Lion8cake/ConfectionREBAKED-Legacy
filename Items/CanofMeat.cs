using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class CanofMeat : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Can of Meat");
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