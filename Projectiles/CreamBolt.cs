using TheConfectionRebirth.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles
{
public class CreamBolt : ModProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Cream Bolt");
	}

	public override void SetDefaults()
	{
		projectile.width = 4;
		projectile.height = 4;
		projectile.friendly = true;
		projectile.magic = true;
		projectile.penetrate = 10;
		projectile.extraUpdates = 100;
		projectile.timeLeft = 300;
		projectile.usesLocalNPCImmunity = true;
		projectile.localNPCHitCooldown = 4;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		projectile.damage = (int)((double)projectile.damage * 1.25);
		projectile.penetrate--;
		if (projectile.penetrate <= 0)
		{
			projectile.Kill();
		}
		else
		{
			projectile.ai[0] += 0.1f;
			if (projectile.velocity.X != oldVelocity.X)
			{
				projectile.velocity.X = 0f - oldVelocity.X;
			}
			if (projectile.velocity.Y != oldVelocity.Y)
			{
				projectile.velocity.Y = 0f - oldVelocity.Y;
			}
		}
		return false;
	}

	public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
	{
		if (target.type != 488)
		{
			projectile.damage = (int)((double)projectile.damage * 1.1);
		}
	}

	public override void AI()
	{
		projectile.localAI[0] += 1f;
		if (projectile.localAI[0] > 9f)
		{
			for (int num447 = 0; num447 < 4; num447++)
			{
				Vector2 vector33 = projectile.position;
				vector33 -= projectile.velocity * ((float)num447 * 0.25f);
				projectile.alpha = 255;
				int num448 = Dust.NewDust(vector33, 1, 1, 133);
				Main.dust[num448].position = vector33;
				Main.dust[num448].scale = (float)Main.rand.Next(70, 110) * 0.013f;
				Dust obj = Main.dust[num448];
				obj.velocity *= 0.2f;
			}
		}
	}
}
}