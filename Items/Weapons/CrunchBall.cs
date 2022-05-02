using TheConfectionRebirth.Items;
using TheConfectionRebirth.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
	public class CrunchBall : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crunch Ball");
			Tooltip.SetDefault("Launches a large Rock Candy ball.");
		}
	
		public override void SetDefaults()
		{
			item.damage = 38;
			item.magic = true;
			item.mana = 4;
			item.width = 28;
			item.height = 30;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2f;
			item.value = 500000;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item17;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<RockCandy>();
			item.shootSpeed = 16f;
		}
	
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.Saccharite>(), 30);
			recipe.AddIngredient(ModContent.ItemType<Items.SoulofDelight>(), 15);
			recipe.AddIngredient(ItemID.SpellTome, 1);
			recipe.AddTile(TileID.Bookcases);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}