using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class KeyofDelight : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Key of Delight");
			Tooltip.SetDefault("'Charged with the essence of many souls'");
		}

		public override void SetDefaults() 
		{
			item.width = 10;
			item.height = 12;
			item.maxStack = 99;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.SoulofDelight>(), 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}