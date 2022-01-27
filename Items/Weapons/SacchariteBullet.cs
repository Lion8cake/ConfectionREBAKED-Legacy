using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
	public class SacchariteBullet : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shatters into pecies apon impact.");
		}

		public override void SetDefaults() {
			item.damage = 4;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true; 
			item.knockBack = 1.5f;
			item.value = 30;
			item.rare = ItemRarityID.Orange;
			item.shoot = ModContent.ProjectileType<Projectiles.SacchariteBullet>();
			item.shootSpeed = 16f;
			item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 25);
			recipe.AddIngredient(ModContent.ItemType<Placeable.Saccharite>(), 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 25);
			recipe.AddRecipe();
		}
	}
}
