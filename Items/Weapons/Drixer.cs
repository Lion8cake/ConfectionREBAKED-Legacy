using TheConfectionRebirth.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
	public class Drixer : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Not to be confused with a Drax'");
		}

		public override void SetDefaults() {
			item.damage = 34;
			item.melee = true;
			item.width = 20;
			item.height = 12;
			item.useTime = 4;
			item.useAnimation = 15;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.axe = 22;
			item.pick = 200;
			item.tileBoost++;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 440);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Drixer>();
			item.shootSpeed = 40f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<NeapoliniteBar>(), 18);
			recipe.AddIngredient(ItemID.SoulofSight, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}