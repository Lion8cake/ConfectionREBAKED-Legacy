using TheConfectionRebirth.Tiles;
using TheConfectionRebirth.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
	public class PopRocket : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Fires 4 Icy-Rockets after your enemys.");
		}

		public override void SetDefaults() {
			item.damage = 58; 
			item.magic = true;
		    item.mana = 55;
			item.width = 40; 
			item.height = 20; 
			item.useTime = 20; 
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut; 
			item.noMelee = true; 
			item.knockBack = 4; 
			item.rare = ItemRarityID.Yellow; 
			item.UseSound = SoundID.Item11; 
			item.value = Item.sellPrice(silver: 700);
			item.autoReuse = true; 
			item.shoot = 10; 
			item.shootSpeed = 16f; 
			item.shoot = mod.ProjectileType("PopRocket");
			item.useAnimation = 12;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
         int numberProjectiles = 3 + Main.rand.Next(3); 
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
	}
}
