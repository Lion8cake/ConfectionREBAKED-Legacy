using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Placeable
{
	public class ConfectionBiomeChestItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Confection Chest");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 22;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 2500;
			item.createTile = mod.TileType("ConfectionBiomeChestTile");
		}
	}
}
