using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class YumDrop : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("YumDrop");
		}

		public override void SetDefaults() 
		{
			item.width = 10;
			item.height = 12;
			item.value = 15000;
			item.rare = ItemRarityID.White;
			item.maxStack = 99;
		}
	}
}