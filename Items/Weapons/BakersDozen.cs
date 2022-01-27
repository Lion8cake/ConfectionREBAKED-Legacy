using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheConfectionRebirth.Projectiles;

namespace TheConfectionRebirth.Items.Weapons
{
public class BakersDozen : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Baker's Dozen");
	}

	public override void SetDefaults()
	{
		item.width = 38;
		item.damage = 32;
		item.noMelee = true;
		item.noUseGraphic = true;
		item.autoReuse = true;
		item.useAnimation = 14;
		item.useStyle = 1;
		item.useTime = 14;
		item.knockBack = 7.5f;
		item.UseSound = SoundID.Item1;
		item.melee = true;
		item.height = 38;
		item.value = 600000;
		item.rare = 5;
		item.shoot = mod.ProjectileType("BakersDozen");
		item.shootSpeed = 16f;
	}
	
	public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.NeapoliniteBar>(), 15);
			recipe.AddIngredient(ModContent.ItemType<Items.SoulofDelight>(), 20);
			recipe.AddIngredient(ItemID.SoulofMight, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}
}
