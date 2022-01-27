using TheConfectionRebirth.Projectiles;
using TheConfectionRebirth.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
	public class CreamofKickin : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Cream of Kickin'");
			Tooltip.SetDefault("Apon using <right> a cookie will shoot with increased speed but less damage."
			    + "\nApon using <left> a ball of meat will shoot with increased damage but less speed.");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = Item.sellPrice(silver: 288);
			item.rare = ItemRarityID.Pink;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 4f;
			item.damage = 45;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<CreamofKickinMeatball>();
			item.shootSpeed = 15.1f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.crit = 15;
			item.channel = true;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.CreamPuff>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Items.CanofMeat>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Items.SoulofDelight>(), 7);
			recipe.AddIngredient(ModContent.ItemType<Items.SoulofSpite>(), 7);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool AltFunctionUse(Player player) {
			return true;
		}

		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2) {
				item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 4f;
				item.damage = 38;
				item.noUseGraphic = true;
				item.shoot = ModContent.ProjectileType<CreamofKickinCookie>();
				item.shootSpeed = 15.1f;
			    item.UseSound = SoundID.Item1;
			    item.melee = true;
			    item.crit = 15;
			    item.channel = true;
			}
			else {
				item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 4f;
				item.damage = 45;
				item.noUseGraphic = true;
				item.shoot = ModContent.ProjectileType<CreamofKickinMeatball>();
				item.shootSpeed = 15.1f;
			    item.UseSound = SoundID.Item1;
			    item.melee = true;
			    item.crit = 15;
			    item.channel = true;
			}
			return base.CanUseItem(player);
		}
	}
}