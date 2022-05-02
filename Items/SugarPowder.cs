using TheConfectionRebirth;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class SugarPowder : ModItem
	{
	   public override void SetStaticDefaults()
	   {
		   Tooltip.SetDefault("Cleanses the evil");
       }

	   public override void SetDefaults()
	   {
		   item.shoot = mod.ProjectileType("SugarPowder");
		   item.useStyle = 1;
		   item.shootSpeed = 4f;
		   item.width = 16;
		   item.height = 24;
		   item.maxStack = 99;
		   item.consumable = true;
		   item.UseSound = SoundID.Item1;
		   item.useAnimation = 15;
		   item.useTime = 15;
		   item.noMelee = true;
		   item.value = 75;
	    }
		  
		public override void AddRecipes() 
		{
            ModRecipe recipe5 = new ModRecipe(mod);
            recipe5.AddIngredient(ModContent.ItemType<Items.YumDrop>(), 1);
            recipe5.AddTile(13);
            recipe5.SetResult(this, 5);
            recipe5.AddRecipe();
        }
	}
}