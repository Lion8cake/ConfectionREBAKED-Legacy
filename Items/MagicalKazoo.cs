using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class MagicalKazoo : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Magical Kazoo");
			Tooltip.SetDefault("Summons a shiny Birdnana");
		}

		public override void SetDefaults() {
			item.damage = 0;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.shoot = ModContent.ProjectileType<Projectiles.Pets.BirdnanaLightPet>();
			item.width = 16;
			item.height = 30;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/kazooSound");
			item.useAnimation = 20;
			item.useTime = 20;
			item.rare = ItemRarityID.Pink;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.buffType = ModContent.BuffType<Buffs.BirdnanaLightPetBuff>();
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Sprinkles>(), 80);
			recipe.AddIngredient(ModContent.ItemType<Items.SoulofDelight>(), 12);
			recipe.AddIngredient(ItemID.SoulofSight, 20);
			recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Kazoo>(), 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}