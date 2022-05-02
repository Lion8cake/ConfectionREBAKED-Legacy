using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Placeable
{
	public class CreamstoneBrick : ModItem
	{
		public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.CreamstoneBrick>();
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(ModContent.ItemType<Items.Placeable.Creamstone>(), 1);
			recipe1.AddIngredient(ModContent.ItemType<Items.Placeable.Creamsand>(), 1);
			recipe1.AddTile(TileID.Furnaces);
			recipe1.SetResult(this);
			recipe1.AddRecipe();
			
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ModContent.ItemType<Items.Placeable.CreamstoneBrickWall>(), 4);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
	}
}
