using TheConfectionRebirth.Items.Placeable;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheConfectionRebirth.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class NeapoliniteGreaves : ModItem
	{
		public override void SetStaticDefaults() {
		Tooltip.SetDefault("5% Increased Damage"
				+ "\n7% Increased Movement Speed");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 150000;
			item.rare = ItemRarityID.Pink;
			item.defense = 8;
		}
		
		public override void UpdateEquip(Player player) {
			player.meleeDamage += 0.05f;
			player.rangedDamage += 0.05f;
			player.magicDamage += 0.05f;
			player.minionDamage += 0.05f;
			player.moveSpeed += 0.07f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.NeapoliniteBar>(), 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}