using TheConfectionRebirth.Items.Placeable;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Placeable
{
	public class HallowedOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[item.type] = 58;
		}

		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.HallowedOre>();
			item.width = 12;
			item.height = 12;
			item.value = 3000;
			item.rare = ItemRarityID.LightRed;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this, 5);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(ItemID.HallowedBar, 1);
			recipe.AddRecipe();
		}
	}
}
