using TheConfectionRebirth.Tiles;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Placeable
{
public class ConfectionPainting : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("The Deserted Land");
		Tooltip.SetDefault("'S. Bobble'");
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
		item.value = 10000;
		item.createTile = ModContent.TileType<Tiles.ConfectionPainting>();
		item.placeStyle = 0;
	}
}
}