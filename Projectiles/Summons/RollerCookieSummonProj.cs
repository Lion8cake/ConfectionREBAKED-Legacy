using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TheConfectionRebirth;
using TheConfectionRebirth.Tiles;
using TheConfectionRebirth.Walls;
using TheConfectionRebirth.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.World.Generation;
using TheConfectionRebirth.Dusts;
using TheConfectionRebirth.Projectiles.Summons;
using TheConfectionRebirth.Buffs;

namespace TheConfectionRebirth.Projectiles.Summons
{
    public class RollerCookieSummonProj : ModProjectile
    {
		
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Miniture Roller Cookie");
		Main.projFrames[projectile.type] = 11;
		ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
		ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
	}

	public override void SetDefaults()
	{
		projectile.width = 26;
		projectile.height = 26;
		projectile.netImportant = true;
		projectile.friendly = true;
		projectile.minionSlots = 1f;
		projectile.aiStyle = 26;
		projectile.timeLeft = 18000;
		projectile.penetrate = -1;
		projectile.timeLeft *= 5;
		projectile.minion = true;
		aiType = 390;
		projectile.tileCollide = false;
	}

	public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
	{
		fallThrough = false;
		return true;
	}
	
	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		if (projectile.penetrate == 0)
		{
			projectile.Kill();
		}
		return false;
	}
	public override void AI() {
	                     Player player = Main.player[projectile.owner];
			
			#region Active check
			if (player.dead || !player.active) {
				player.ClearBuff(ModContent.BuffType<RollerCookieSummonBuff>());
			}
			if (player.HasBuff(ModContent.BuffType<RollerCookieSummonBuff>())) {
				projectile.timeLeft = 2;
			}
			#endregion
	}
    }
}
