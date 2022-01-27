using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class Cakekite : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cakekite");
		}

		public override void SetDefaults() 
		{
			item.width = 10;
			item.height = 12;
			item.value = 50000;
			item.rare = 3;
			item.maxStack = 999;
		}
		
		public override void AddRecipes()
		{
		    ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(this, 1);
			recipe1.AddIngredient(ItemID.BottledWater, 1);
			recipe1.AddIngredient(ItemID.Shiverthorn, 1);
			recipe1.AddIngredient(ItemID.Moonglow, 1);
			recipe1.AddIngredient(ItemID.Waterleaf, 1);
			recipe1.AddTile(TileID.AlchemyTable);
			recipe1.SetResult(ItemID.LifeforcePotion, 1);
			recipe1.AddRecipe();
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(this, 2);
			recipe2.AddTile(96);
			recipe2.SetResult(ItemID.CookedFish, 1);
			recipe2.AddRecipe();
		}
	}
}