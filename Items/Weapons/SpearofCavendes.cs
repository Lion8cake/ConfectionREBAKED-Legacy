using TheConfectionRebirth.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
	public class SpearofCavendes : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Spear of Cavendes");
		}

		public override void SetDefaults() {
			item.damage = 40;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 18;
			item.useTime = 24;
			item.shootSpeed = 3.7f;
			item.knockBack = 6.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.Pink;
			item.value = Item.sellPrice(silver: 460);
			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SpearofCavendesProj>();
			item.shootSpeed = 10f;
		}

		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		
	    	public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    	{
    		Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("SpearofCavendesProj"), damage, knockBack, player.whoAmI);
	    	Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("SpearofCavendesBannana"), damage, knockBack, player.whoAmI);
    		return false;
    	} 
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.NeapoliniteBar>(), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
