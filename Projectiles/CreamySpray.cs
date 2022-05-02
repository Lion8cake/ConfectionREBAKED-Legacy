using TheConfectionRebirth.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheConfectionRebirth.Projectiles
{
	public class CreamySpray : ModProjectile
	{
		public override string Texture => "TheConfectionRebirth/Projectiles/CreamBolt";
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spray");
		}
	
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.penetrate = 6;
			projectile.extraUpdates = 2;
			projectile.magic = true;
		}
	
		public override void AI()
		{
			Lighting.AddLight(projectile.Center, (float)(255 - projectile.alpha) * 0.01f / 255f, (float)(255 - projectile.alpha) * 0.15f / 255f, (float)(255 - projectile.alpha) * 0.05f / 255f);
			projectile.scale -= 0.002f;
			if (projectile.scale <= 0f)
			{
				projectile.Kill();
			}
			if (projectile.ai[0] <= 3f)
			{
				projectile.ai[0] += 1f;
				return;
			}
			projectile.velocity.Y = projectile.velocity.Y + 0.075f;
			for (int num151 = 0; num151 < 3; num151++)
			{
				float num152 = projectile.velocity.X / 3f * (float)num151;
				float num153 = projectile.velocity.Y / 3f * (float)num151;
				int num154 = 14;
				int num155 = Dust.NewDust(new Vector2(projectile.position.X + (float)num154, projectile.position.Y + (float)num154), projectile.width - num154 * 2, projectile.height - num154 * 2, 133, 0f, 0f, 100);
				Dust obj = Main.dust[num155];
				obj.noGravity = true;
				obj.velocity *= 0.1f;
				obj.velocity += projectile.velocity * 0.5f;
				obj.position.X -= num152;
				obj.position.Y -= num153;
			}
			if (Main.rand.NextBool(8))
			{
				int num156 = 16;
				int num133 = Dust.NewDust(new Vector2(projectile.position.X + (float)num156, projectile.position.Y + (float)num156), projectile.width - num156 * 2, projectile.height - num156 * 2, 133, 0f, 0f, 100, default(Color), 0.5f);
				Dust obj2 = Main.dust[num133];
				obj2.velocity *= 0.25f;
				Dust obj3 = Main.dust[num133];
				obj3.velocity += projectile.velocity * 0.5f;
			}
		}
	
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D tex = Main.projectileTexture[projectile.type];
			spriteBatch.Draw(tex, projectile.Center - Main.screenPosition, (Rectangle?)null, projectile.GetAlpha(lightColor), projectile.rotation, tex.Size() / 2f, projectile.scale, (SpriteEffects)0, 0f);
			return false;
		}
	}
}