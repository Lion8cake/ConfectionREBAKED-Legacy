using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
	public class TrueSucrosa : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("True Sucrosa");
		}

		public override void SetDefaults() 
		{
			item.damage = 85;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 1000);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("TrueSucrosaBolt");
			item.shootSpeed = 8f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 2 + Main.rand.Next(2);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25));

				int spirit = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				Main.projectile[spirit].magic = false;
				Main.projectile[spirit].melee = true;
			}
			return false; 
		}
        public override bool OnlyShootOnSwing => base.OnlyShootOnSwing;
		
		public override void AddRecipes() // thanks to foxyboy55 for this fix
		{
			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(ModContent.ItemType<Items.Weapons.Sucrosa>(), 1);
			recipe1.AddIngredient(ItemID.BrokenHeroSword, 1);
			recipe1.AddTile(TileID.MythrilAnvil);
			recipe1.SetResult(this);
			recipe1.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ModContent.ItemType<Items.Weapons.TrueDeathsRaze>(), 1);
			recipe2.AddIngredient(this, 1);
			recipe2.AddTile(TileID.MythrilAnvil);
			recipe2.SetResult(ItemID.TerraBlade, 1);
			recipe2.AddRecipe();

            ModRecipe recipe3 = new ModRecipe(mod);
            recipe3.AddIngredient(675, 1);
            recipe3.AddIngredient(this, 1);
            recipe3.AddTile(TileID.MythrilAnvil);
            recipe3.SetResult(ItemID.TerraBlade, 1);
            recipe3.AddRecipe();

            ModRecipe recipe4 = new ModRecipe(mod);
            recipe4.AddIngredient(ModContent.ItemType<Items.Weapons.TrueDeathsRaze>(), 1);
            recipe4.AddIngredient(674, 1);
            recipe4.AddTile(TileID.MythrilAnvil);
            recipe4.SetResult(ItemID.TerraBlade, 1);
            recipe4.AddRecipe();
        }
	}
}