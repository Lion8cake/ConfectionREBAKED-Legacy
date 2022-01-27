using TheConfectionRebirth.Projectiles;
using TheConfectionRebirth.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
	public class IcecreamBell : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Do you scream, for Ice-cream?");
		}

		public override void SetDefaults() {
			item.damage = 38;
			item.magic = true;
			item.mana = 4;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 200000;
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item35;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<IcecreamBall>();
			item.shootSpeed = 7.5f;
		}
		
		    public override Vector2? HoldoutOffset()
	    {
		    return new Vector2(-4f, 4f);
	    }

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.Saccharite>(), 50);
			recipe.AddIngredient(ModContent.ItemType<Items.SoulofDelight>(), 12);
			recipe.AddIngredient(ItemID.SoulofSight, 20);
			recipe.AddIngredient(ItemID.Bell, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}