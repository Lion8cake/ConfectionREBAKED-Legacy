using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles
{
    class DimWarp2 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "Dimensional Warp";
            projectile.width = 32;
            projectile.height = 38;
            projectile.friendly = true;
            projectile.hostile = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 10;
            projectile.ai[0] = 0;
        }
		
		public override void SetStaticDefaults() {
			Main.projFrames[projectile.type] = 8;
		}

        public override void AI()
        {			
			if (++projectile.frameCounter >= 5) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 8) {
					projectile.frame = 0;
				}
			}
        }
		
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.boss == false)
            {
                Projectile warppoint = Main.player[projectile.owner].GetModPlayer<ConfectionPlayer>().DimensionalWarp;
                target.position.X = warppoint.position.X;
                target.position.Y = warppoint.position.Y;
                target.HealEffect(1);
                projectile.ai[0] = 1;
                projectile.Kill();
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.player[Main.myPlayer] == target)
            {
                Projectile warppoint = Main.player[projectile.owner].GetModPlayer<ConfectionPlayer>().DimensionalWarp;
                target.Teleport(warppoint.position, 1);
                target.HealEffect(1);
                if (target.HasBuff(ModContent.BuffType<Buffs.GoneBananas>()))
                {
                    target.Hurt(PlayerDeathReason.ByCustomReason("DimensionSplit"), (int)((target.statLifeMax2 + target.statDefense) * (target.endurance + 1) / 7), 0);
                }
                target.AddBuff(ModContent.BuffType<Buffs.GoneBananas>(), 360);
                projectile.ai[0] = 1;
                projectile.Kill();
            }
        }
        public override bool PreKill(int timeLeft)
        {
            if (Main.myPlayer == projectile.owner)
            {
                Player owner = Main.player[Main.myPlayer];
                if (projectile.ai[0] == 0)
                {
                    owner.Teleport(owner.GetModPlayer<ConfectionPlayer>().DimensionalWarp.position, 1);
                    owner.GetModPlayer<ConfectionPlayer>().DimensionalWarp.Kill();
                    if (owner.HasBuff(ModContent.BuffType<Buffs.GoneBananas>()))
                    {
                        owner.Hurt(PlayerDeathReason.ByCustomReason("DimensionSplit"), (int)((owner.statLifeMax2 + owner.statDefense) * (owner.endurance + 1) / 7), 0);
                    }
                    owner.AddBuff(ModContent.BuffType<Buffs.GoneBananas>(), 360);
                }
                owner.GetModPlayer<ConfectionPlayer>().DimensionalWarp.Kill();
            }
            return true;
        }
    }
}
