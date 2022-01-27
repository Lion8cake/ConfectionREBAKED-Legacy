using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheConfectionRebirth.Projectiles;

namespace TheConfectionRebirth.Items.Weapons
{
public class SugarWater : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sugar Water");
		Tooltip.SetDefault("Spreads the confection to some blocks");
	}

	public override void SetDefaults()
	{
		item.useStyle = 1;
		item.shootSpeed = 14f;
		item.rare = 3;
		item.damage = 20;
		item.shoot = ModContent.ProjectileType<SugarWaterBottle>();
		item.width = 18;
		item.height = 20;
		item.maxStack = 999;
		item.consumable = true;
		item.knockBack = 3f;
		item.UseSound = SoundID.Item1;
		item.useAnimation = 15;
		item.useTime = 15;
		item.noUseGraphic = true;
		item.noMelee = true;
		item.value = 200;
	}
	
	public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Sprinkles>(), 3);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.CreamBeans>(), 1);
			recipe.AddIngredient(ItemID.BottledWater, 10);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
}
}
