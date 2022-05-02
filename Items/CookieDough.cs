using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class CookieDough : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cookie Dough");
			Tooltip.SetDefault("Don't consume it, it may contain raw eggs.");
		}

		public override void SetDefaults() 
		{
			item.width = 10;
			item.height = 12;
			item.value = 15000;
			item.rare = 1;
			item.maxStack = 99;
		}
		
		public override void AddRecipes() 
		{
            ModRecipe recipe5 = new ModRecipe(mod);
            recipe5.AddIngredient(500, 15);
            recipe5.AddIngredient(ItemID.FallenStar, 1);
            recipe5.AddIngredient(ModContent.ItemType<Items.Placeable.Saccharite>(), 3);
            recipe5.AddIngredient(ModContent.ItemType<Items.CookieDough>(), 1);
            recipe5.AddTile(13);
            recipe5.SetResult(2209, 15);
            recipe5.AddRecipe();
        }
	}
}