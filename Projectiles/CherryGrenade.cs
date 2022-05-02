using Microsoft.Xna.Framework;
using TheConfectionRebirth;
using TheConfectionRebirth.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles
{

	public class CherryGrenade : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cherry Grenade");
		}
	
		public override void SetDefaults()
		{
			projectile.CloneDefaults(30);
			aiType = 30;
			projectile.timeLeft = 200;
			projectile.thrown = true;
			projectile.ranged = true;
		}
	
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = false;
			return true;
		}
	
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item14, projectile.position);
			for (int i = 0; i < 15; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Dust obj = Main.dust[dustIndex];
				obj.velocity *= 1.4f;
			}
			for (int j = 0; j < 10; j++)
			{
				int dustIndex2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex2].noGravity = true;
				Dust obj2 = Main.dust[dustIndex2];
				obj2.velocity *= 5f;
				dustIndex2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
				Dust obj3 = Main.dust[dustIndex2];
				obj3.velocity *= 3f;
			}
			if (Main.myPlayer != projectile.owner)
			{
				return;
			}
			int choice = Main.rand.Next(1);
			if (choice == 0)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ModContent.ProjectileType<CherryShard>(), 24, 1f, Main.myPlayer, 0f, 0f);
			}
			
			int num = Main.rand.Next(1);
			if (num == 0)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ModContent.ProjectileType<CherryShard>(), 24, 1f, Main.myPlayer, 0f, 0f);
			}
			
			int num2 = Main.rand.Next(1);
			if (num2 == 0)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ModContent.ProjectileType<CherryShard>(), 24, 1f, Main.myPlayer, 0f, 0f);
			}
			{
				int num3 = Main.rand.Next(1);
				if (num3 == 0)
				{
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ModContent.ProjectileType<CherryShard>(), 24, 1f, Main.myPlayer, 0f, 0f);
				}
				
				int num4 = Main.rand.Next(1);
				if (num4 == 0)
				{
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ModContent.ProjectileType<CherryShard>(), 24, 1f, Main.myPlayer, 0f, 0f);
				}
			}
		}
	}
}