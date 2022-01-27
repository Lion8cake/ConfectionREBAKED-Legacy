using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles
{
public class RockCandy : ModProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Rock Candy");
	}

	public override void SetDefaults()
	{
		projectile.width = 30;
		projectile.height = 30;
		projectile.friendly = true;
		projectile.aiStyle = 14;
		projectile.penetrate = 4;
		projectile.timeLeft = 360;
		projectile.magic = true;
	}

	public override void AI()
	{
		projectile.velocity.X *= 0.9f;
		projectile.velocity.Y *= 0.99f;
		projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
	}
	
	public override void Kill(int timeLeft)
	{
		float spread = 1.566f;
		double startAngle = Math.Atan2(projectile.velocity.X, projectile.velocity.Y) - (double)(spread / 2f);
		double deltaAngle = spread / 8f;
		if (projectile.owner == Main.myPlayer)
		{
			for (int i = 0; i < 4; i++)
			{
				double offsetAngle = startAngle + deltaAngle * (double)(i + i * i) / 2.0 + (double)(32f * (float)i);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)(Math.Sin(offsetAngle) * 5.0), (float)(Math.Cos(offsetAngle) * 5.0), ModContent.ProjectileType<RockCandyShard>(), (int)((double)projectile.damage * 0.75), projectile.knockBack, projectile.owner, projectile.ai[0]);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)((0.0 - Math.Sin(offsetAngle)) * 5.0), (float)((0.0 - Math.Cos(offsetAngle)) * 5.0), ModContent.ProjectileType<RockCandyShard>(), (int)((double)projectile.damage * 0.75), projectile.knockBack, projectile.owner, projectile.ai[0]);
			}
		}
	}
}
}