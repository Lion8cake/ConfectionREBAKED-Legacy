using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class CreamPuff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cream Puff"); 
			Tooltip.SetDefault("'Sometimes carried by creatures in the dessert desert'");
		}

		public override void SetDefaults() 
		{
			item.width = 10;
			item.height = 12;
			item.value = 4500;
			item.rare = ItemRarityID.Green;
			item.maxStack = 99;
		}
		
		public override void AddRecipes()
		{											
 		 ModRecipe recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(null, "CreamPuff", 1);
    	 recipe.AddTile(26);
 		 recipe.SetResult(ItemID.LightShard, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(ItemID.LightShard, 1);
    	 recipe.AddTile(26);
 		 recipe.SetResult(null, "CreamPuff", 1);
  		 recipe.AddRecipe();
		}
	}
}