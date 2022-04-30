using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheConfectionRebirth.Projectiles;

namespace TheConfectionRebirth.Items.Weapons
{
	public class PopSoda : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soda Potion");
			Tooltip.SetDefault("'I believe this belongs to Emmie'");
		}
	
		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.shootSpeed = 14f;
			item.rare = 3;
			item.damage = 60;
			item.magic = true;
			item.mana = 20;
			item.shoot = ModContent.ProjectileType<PopSodaProjectile>();
			item.width = 18;
			item.height = 20;
			item.maxStack = 1;
			item.knockBack = 3f;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 15;
			item.useTime = 15;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = 2000;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
         int numberProjectiles = 5 + Main.rand.Next(5); 
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
		
		public class KeyGlobalNPC : GlobalNPC
	    {
	    	public override void NPCLoot(NPC npc) {
	    		if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ConfectionPlayer>().ZoneConfection) {
		    	    if (Main.rand.Next(2000) == 0)
                    {
		    		Item.NewItem(npc.getRect(), ModContent.ItemType<PopSoda>(), 1);
		     		}
		    	}
	    	}
    	}
	}
}
