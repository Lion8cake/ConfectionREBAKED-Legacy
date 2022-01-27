using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles
{
public class BakersDozen : ModProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Baker's Dozen");
	}

	public override void SetDefaults()
	{
		projectile.width = 30;
		projectile.height = 30;
		projectile.friendly = true;
		projectile.penetrate = -1;
		projectile.aiStyle = 3;
		projectile.timeLeft = 600;
		aiType = 52;
		projectile.melee = true;
	}
}
}
