using TheConfectionRebirth.Mounts;
using TheConfectionRebirth.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class DriversPermint : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Driver's Permint");
			Tooltip.SetDefault("Summons a Rollercycle to ride on");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 250000;
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
			item.mountType = ModContent.MountType<Rollercycle>();
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "KeyofDelight", 1);
			recipe.AddIngredient(null, "NeapoliniteBar", 30);
			recipe.AddIngredient(null, "Sprinkles", 80);
			recipe.AddIngredient(null, "CookieDough", 20);
			recipe.AddIngredient(null, "Saccharite", 100);
			recipe.AddIngredient(null, "SoulofDelight", 30);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}