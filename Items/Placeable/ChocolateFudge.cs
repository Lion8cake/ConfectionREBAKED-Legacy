using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Placeable
{
	public class ChocolateFudge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chocolate Fudge");
			Tooltip.SetDefault("A honey like chocolate block");
		}

		public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.ChocolateFudge>();
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Creamsand", 30);
			recipe.AddIngredient(1134, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 30);
			recipe.AddRecipe();
		}
	}
}
