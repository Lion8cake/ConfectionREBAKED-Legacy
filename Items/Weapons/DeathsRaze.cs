using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
	public class DeathsRaze : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Death's Raze");
		}

		public override void SetDefaults() 
		{
			item.damage = 45;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 15;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 54000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BloodButcherer, 1);
			recipe.AddIngredient(ItemID.Muramasa, 1);
			recipe.AddIngredient(ItemID.BladeofGrass, 1);
			recipe.AddIngredient(ItemID.FieryGreatsword, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}