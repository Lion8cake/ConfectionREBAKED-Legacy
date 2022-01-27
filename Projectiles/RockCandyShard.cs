using System;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles
{
public class RockCandyShard : ModProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Rock Candy");
	}

	public override void SetDefaults()
	{
		projectile.width = 8;
		projectile.height = 8;
		projectile.friendly = true;
		projectile.aiStyle = 14;
		projectile.penetrate = 4;
		projectile.timeLeft = 360;
		projectile.magic = true;
		projectile.ranged = true;
	}

	public override void AI()
	{
		projectile.velocity.X *= 0.9f;
		projectile.velocity.Y *= 0.99f;
		projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
	}
}
}