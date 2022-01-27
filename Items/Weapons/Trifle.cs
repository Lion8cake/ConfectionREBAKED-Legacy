using TheConfectionRebirth.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
	public class Trifle : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("30% Not to consume ammo");
		}

		public override void SetDefaults() {
			item.damage = 23; 
			item.ranged = true; 
			item.width = 40; 
			item.height = 20; 
			item.useTime = 10; 
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut; 
			item.noMelee = true; 
			item.knockBack = 4; 
			item.rare = ItemRarityID.Pink; 
			item.UseSound = SoundID.Item11; 
			item.autoReuse = true; 
			item.shoot = 10; 
			item.shootSpeed = 16f; 
			item.value = 300000;
			item.useAmmo = AmmoID.Bullet; 
			item.useAnimation = 12;
			item.useTime = 4;
			item.reuseDelay = 14;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ClockworkAssaultRifle, 1);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddIngredient(ModContent.ItemType<Items.SoulofDelight>(), 15);
			recipe.AddIngredient(ModContent.ItemType<Items.Sprinkles>(), 20);
			recipe.AddIngredient(ItemID.SoulofMight, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
