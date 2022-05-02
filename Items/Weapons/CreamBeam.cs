using TheConfectionRebirth;
using TheConfectionRebirth.Items;
using TheConfectionRebirth.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
	public class CreamBeam : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cream Beam");
			Item.staff[item.type] = true;
		}
	
		public override void SetDefaults()
		{
			item.damage = 54;
			item.magic = true;
			item.mana = 18;
			item.width = 25;
			item.height = 25;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 8f;
			item.value = Item.sellPrice(silver: 400);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item72;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<CreamBolt>();
			item.shootSpeed = 6f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofSight, 20);
			recipe.AddIngredient(ModContent.ItemType<Items.SoulofDelight>(), 10);
			recipe.AddIngredient(ModContent.ItemType<Items.Sprinkles>(), 60);
			recipe.AddIngredient(ModContent.ItemType<Items.CookieDough>(), 6);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.Saccharite>(), 25);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}