using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class Sprinkles : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sprinkles");
		}

		public override void SetDefaults() 
		{
			item.width = 10;
			item.height = 12;
			item.value = 500;
			item.rare = 1;
			item.maxStack = 99;
		}
		
		public override void AddRecipes()
		{
		    ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(this, 3);
			recipe1.AddIngredient(ModContent.ItemType<Items.Placeable.Saccharite>(), 1);
			recipe1.AddIngredient(ItemID.BottledWater, 3);
			recipe1.AddTile(TileID.AlchemyTable);
			recipe1.SetResult(ItemID.GreaterHealingPotion, 3);
			recipe1.AddRecipe();
		}
	}
}