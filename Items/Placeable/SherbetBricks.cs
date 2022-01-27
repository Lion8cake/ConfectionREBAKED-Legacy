using TheConfectionRebirth.Tiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Placeable
{
  public class SherbetBricks : ModItem
  {
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sherbet Brick");
	}

	public override void SetDefaults()
	{
		item.width = 32;
		item.height = 16;
		item.maxStack = 999;
		item.useTurn = true;
		item.autoReuse = true;
		item.noUseGraphic = true;
		item.useAnimation = 15;
		item.useTime = 10;
		item.useStyle = 1;
		item.value = Item.buyPrice(0, 0, 15);
		item.consumable = true;
		item.createTile = ModContent.TileType<Tiles.SherbetBricks>();
	}
  } 
}
