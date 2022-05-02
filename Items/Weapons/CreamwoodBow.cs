using TheConfectionRebirth.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
	public class CreamwoodBow : ModItem
	{
		public override void SetDefaults() {
			item.damage = 9; 
			item.ranged = true; 
			item.width = 40; 
			item.height = 20;
			item.useTime = 20; 
			item.useAnimation = 20; 
			item.value = 100;
			item.useStyle = ItemUseStyleID.HoldingOut; 
			item.noMelee = true; 
			item.rare = ItemRarityID.White; 
			item.UseSound = SoundID.Item5; 
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.CreamWood>(), 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
