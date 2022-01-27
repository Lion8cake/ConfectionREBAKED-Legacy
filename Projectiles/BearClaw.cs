using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles
{
public class BearClaw : ModProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Bear Claw");
	}

	public override void SetDefaults()
	{
		projectile.width = 20;
		projectile.height = 20;
		projectile.friendly = true;
		projectile.penetrate = -1;
		projectile.aiStyle = 3;
		projectile.timeLeft = 600;
		aiType = 52;
		projectile.melee = true;
	}
}
}
