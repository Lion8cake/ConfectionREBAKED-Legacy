using System;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles
{
	public class BlueFairyFlossRain : ModProjectile
	{   
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rain");
		}
	
		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
			projectile.timeLeft = 100;
			projectile.aiStyle = 1;
			projectile.penetrate = -1;
		}
		
	}
}