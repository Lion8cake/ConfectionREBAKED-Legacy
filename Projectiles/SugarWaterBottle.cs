using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TheConfectionRebirth.Dusts;

namespace TheConfectionRebirth.Projectiles
{
public class SugarWaterBottle : ModProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Bottle");
	}

	public override void SetDefaults()
	{
		projectile.width = 14;
		projectile.height = 14;
		projectile.aiStyle = 2;
		projectile.friendly = true;
		projectile.penetrate = 1;
	}

	public override void AI()
	{
		projectile.ai[0] += 1f;
		if (projectile.ai[0] >= 10f)
		{
			projectile.velocity.Y += 0.1f;
			projectile.velocity.X *= 0.998f;
		}
	}

	public override void Kill(int timeLeft)
	{
		if (projectile.owner == Main.myPlayer)
		{
			Main.PlaySound(13, (int)projectile.position.X, (int)projectile.position.Y);
			for (int index = 0; index < 5; index++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 13);
			}
			for (int index2 = 0; index2 < 30; index2++)
			{
				int index3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<CreamWaterSplash>(), 0f, -2f, 0, default(Color), 1.1f);
				Dust obj = Main.dust[index3];
				obj.alpha = 100;
				obj.velocity.X *= 1.5f;
				obj.velocity *= 3f;
			}
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), ModContent.ProjectileType<CreamSolution>(), 24, 1f, Main.myPlayer, 0f, 0f);
		}
	}
}
}
