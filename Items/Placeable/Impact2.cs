using TheConfectionRebirth.Tiles;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Placeable
{
	public class Impact2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Impact");
			Tooltip.SetDefault("'L. Cake'");
		}
	
		public override void SetDefaults()
		{
			item.width = 44;
			item.height = 24;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 5000;
			item.createTile = ModContent.TileType<Tiles.Impact2>();
			item.placeStyle = 0;
		}
	}
}