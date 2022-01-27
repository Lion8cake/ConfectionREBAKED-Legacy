using TheConfectionRebirth.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class NeapoliniteConeMail : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Neapolinite Cone Mail");
			Tooltip.SetDefault("5% Increased Critical Strike Chance");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 200000;
			item.rare = ItemRarityID.Pink;
			item.defense = 13;
		}
		
		public override void UpdateEquip(Player player) {
			player.meleeCrit += 5;
			player.magicCrit += 5;
			player.rangedCrit += 5;
			player.thrownCrit += 5;
		}

         public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.NeapoliniteBar>(), 24);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}   
	}
}