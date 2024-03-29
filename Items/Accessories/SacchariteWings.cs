using TheConfectionRebirth.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheConfectionRebirth.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class SacchariteWings : ModItem
	{
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = 400000;
			item.rare = ItemRarityID.Pink;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 67;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 10f;
			acceleration *= 2.5f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.Saccharite>(), 25);
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}