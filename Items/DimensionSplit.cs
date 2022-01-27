using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheConfectionRebirth.Projectiles;
using Terraria.DataStructures;

namespace TheConfectionRebirth.Items
{
    class DimensionSplit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dimensional Split");
			Tooltip.SetDefault("When used places a portal and when clicked on a npc teleports it to the first portal");
        }
        public override void SetDefaults()
        {
            item.useTime = 15;
            item.useAnimation = 15;
            item.width = 30;
            item.height = 30;
            item.useStyle = 1;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.shoot = ModContent.ProjectileType<DimWarp>();
            item.UseSound = SoundID.Item8;
			item.autoReuse = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            ConfectionPlayer modPlayer = player.GetModPlayer<ConfectionPlayer>();
            int tileX = (int)((Main.mouseX + Main.screenPosition.X) / 16);
            int tileY = (int)((Main.mouseY + Main.screenPosition.Y) / 16);
            if (modPlayer.DimensionalWarp == null && (!Main.tile[tileX, tileY].active() || !Main.tileSolid[Main.tile[tileX, tileY].type])) 
            {
                Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
            } else if (modPlayer.DimensionalWarp != null)
            {
                Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, speedX, speedY, ModContent.ProjectileType<DimWarp2>(), 1, knockBack, Main.myPlayer); ;
            }
            return false;
        }
    }
}
