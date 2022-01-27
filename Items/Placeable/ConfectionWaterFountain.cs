using TheConfectionRebirth.Tiles;
using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Placeable
{
public class ConfectionWaterFountain : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Confection Water Fountain");
	}

	public override void SetDefaults()
	{
		item.width = 22;
		item.height = 42;
		item.maxStack = 999;
	    item.useTurn = true;
		item.autoReuse = true;
		item.useAnimation = 15;
		item.useTime = 10;
		item.useStyle = 1;
		item.consumable = true;
		item.value = Item.buyPrice(0, 4);
		item.rare = 0;
		item.createTile = ModContent.TileType<Tiles.ConfectionWaterFountain>();
	}
}
}