using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Placeable
{
	public class NeapoliniteBrick : ModItem
	{
		public override void SetStaticDefaults() {
		}

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
			item.createTile = ModContent.TileType<Tiles.NeapoliniteBrick>();
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.NeapoliniteOre>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.Creamstone>(), 1);	
			recipe.AddTile(17);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
