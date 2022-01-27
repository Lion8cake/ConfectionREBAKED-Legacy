using TheConfectionRebirth.Dusts;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace TheConfectionRebirth.Projectiles
{
    public class TrueIchorBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.timeLeft = 80;
            projectile.alpha = 0;
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.penetrate = -1;
            drawOffsetX = -24;
        }
        public override void AI()
        {
            projectile.alpha += 20;
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            if (projectile.timeLeft <= 25)
            {
                projectile.scale *= 0.97f;
            }
            if (projectile.timeLeft <= 20)
            {
                projectile.scale *= 0.95f;
            }
            if (projectile.timeLeft <= 15)
            {
                projectile.scale *= 0.93f;
            }
            if (projectile.timeLeft <= 10)
            {
                projectile.scale *= 0.91f;
            }
            float num1 = 1f;
            if (projectile.timeLeft <= 15)
            {
                num1 = 0.5f;
            }
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<IchorDrops>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            Main.dust[dust].noGravity = true;
            if (Main.rand.Next(3) == 0)
            {
                int dust1 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<IchorDrops>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
                Main.dust[dust1].noGravity = true;
            }
        }

        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            if (projectile.timeLeft >= 15)
            {
                int size = 20;
                hitbox.X -= size;
                hitbox.Y -= size;
                hitbox.Width += size * 2;
                hitbox.Height += size * 2;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, this.projectile.alpha);
        }
    }
}