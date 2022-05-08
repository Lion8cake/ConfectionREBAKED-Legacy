using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles
{
    public class SacchariteDartPro : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 30;
            projectile.aiStyle = 27;
            projectile.friendly = true;
            projectile.melee = false;
            projectile.tileCollide = false;
            projectile.penetrate = 1;
            projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.IchorDart;
        }

        public override void AI()
        {
			projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
			projectile.rotation = projectile.velocity.ToRotation();
            float CenterX = projectile.Center.X;
            float CenterY = projectile.Center.Y;
            float Distanse = 400f;
            bool CheckDistanse = false;
            for (int MobCounts = 0; MobCounts < 200; MobCounts++)
            {
                if (Main.npc[MobCounts].CanBeChasedBy(projectile, false) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[MobCounts].Center, 1, 1))
                {
                    float Position1 = Main.npc[MobCounts].position.X + Main.npc[MobCounts].width / 2;
                    float Position2 = Main.npc[MobCounts].position.Y + Main.npc[MobCounts].height / 2;
                    float Position3 = Math.Abs(projectile.position.X + projectile.width / 2 - Position1) + Math.Abs(projectile.position.Y + projectile.height / 2 - Position2);
                    if (Position3 < Distanse)
                    {
                        Distanse = Position3;
                        CenterX = Position1;
                        CenterY = Position2;
                        CheckDistanse = true;
                    }
                }
            }
            if (CheckDistanse)
            {
                float Speed = 8f;
                Vector2 FinalPos = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                float NewPosX = CenterX - FinalPos.X;
                float NewPosY = CenterY - FinalPos.Y;
                float FinPos = (float)Math.Sqrt(NewPosX * NewPosX + NewPosY * NewPosY);
                FinPos = Speed / FinPos;
                NewPosX *= FinPos;
                NewPosY *= FinPos;
                projectile.velocity.X = (projectile.velocity.X * 20f + NewPosX) / 21f;
                projectile.velocity.Y = (projectile.velocity.Y * 20f + NewPosY) / 21f;
            }

        }
		
		public override void Kill(int timeLeft)
		{
			if (Main.myPlayer != projectile.owner)
			{
				return;
			}
		}
    }
}