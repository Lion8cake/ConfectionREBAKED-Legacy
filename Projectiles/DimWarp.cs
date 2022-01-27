using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles
{
    class DimWarp : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "Dimensional Warp";
            projectile.width = 32;
            projectile.height = 38;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 900;
        }
		
		public override void SetStaticDefaults() {
			Main.projFrames[projectile.type] = 8;
		}

        public override void AI()
        {
            if (projectile.owner == Main.myPlayer)
            {
                Main.player[projectile.owner].GetModPlayer<ConfectionPlayer>().DimensionalWarp = projectile;
                projectile.velocity = new Vector2(0,0);
            }
			
			if (++projectile.frameCounter >= 5) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 8) {
					projectile.frame = 0;
				}
			}
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }
        public override bool PreKill(int timeLeft)
        {
            Main.player[projectile.owner].GetModPlayer<ConfectionPlayer>().DimensionalWarp = null;
            return true;
        }
    }
}
