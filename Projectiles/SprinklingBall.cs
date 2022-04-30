using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles
{
	public class SprinklingBall : ModProjectile
	{	
		public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = false;
            projectile.penetrate = 9;                  
            projectile.hostile = true;                   
            projectile.timeLeft = 250;
			projectile.aiStyle = 14;
        }

		public override void AI()
		{
			if (projectile.alpha > 0)
			{
				projectile.alpha -= 25;
				if (projectile.alpha < 0)
				{
					projectile.alpha = 0;
				}
			}
			projectile.rotation += 0.3f * (float)projectile.direction;
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
			projectile.penetrate--;
			if (projectile.penetrate <= 0) {
				projectile.Kill();
			}
			return false;
		}

		public override void Kill(int timeLeft)
		{
			if (Main.myPlayer != projectile.owner)
			{
				return;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}
	}
}