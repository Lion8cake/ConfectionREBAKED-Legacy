using Terraria.ModLoader;
using Terraria.ID;

namespace TheConfectionRebirth.Items.Placeable
{
	public class ShellBlockWall : ModItem
	{
		public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 7;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createWall = ModContent.WallType<Walls.ShellBlockWall>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ShellBlock>());
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}