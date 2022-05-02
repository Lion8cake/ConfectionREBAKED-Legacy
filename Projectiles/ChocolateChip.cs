using Microsoft.Xna.Framework;
using TheConfectionRebirth;
using TheConfectionRebirth.Projectiles;
using TheConfectionRebirth.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles
{

	public class ChocolateChip : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chocolate Chip");
		}
	
		public override void SetDefaults()
		{
			projectile.CloneDefaults(30);
			aiType = 30;
			projectile.timeLeft = 200;
			projectile.thrown = false;
			projectile.ranged = false;
		}
	
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = false;
			return true;
		}
	
		public override void Kill(int timeLeft)
		{
		for (int k = 0; k < 5; k++) {
					Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<ChipDust>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
				}
			if (Main.myPlayer != projectile.owner)
			{
				return;
			}
		}
	}
}