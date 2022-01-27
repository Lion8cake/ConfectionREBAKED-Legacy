using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheConfectionRebirth.Projectiles;

namespace TheConfectionRebirth.Items.Weapons
{
	public class Candlelighter : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Yes, it's the tricky kind'\nUses gel as ammo\nEnemys will always be on fire unless they fall into water.");
		}

		public override void SetDefaults()
		{
			item.damage = 22;
			item.ranged = true;
			item.width = 50;
			item.height = 18;
			item.useTime = 4;
			item.useAnimation = 20; 
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; 
			item.knockBack = 2; 
			item.value = 500000;
			item.rare = ItemRarityID.Pink; 
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<CandleFlames>();
			item.shootSpeed = 9f; 
			item.useAmmo = AmmoID.Gel; 
		}

		public override bool CanUseItem(Player player)
		{
			return !player.wet;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return player.itemAnimation >= player.itemAnimationMax - 4;
		}


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 54f; 
			if (Collision.CanHit(position, 6, 6, position + muzzleOffset, 6, 6))
			{
				position += muzzleOffset;
			}
			return true;
        }
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -2);
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.NeapoliniteBar>(), 12);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddIngredient(ItemID.SoulofSight, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
