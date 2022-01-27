using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles.Pets
{

public class BirdnanaLightPet : ModProjectile
{

	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Shiny Birdnana");
		Main.projFrames[projectile.type] = 4;
		Main.projPet[projectile.type] = true;
		ProjectileID.Sets.LightPet[projectile.type] = true;
	}

	public override void SetDefaults()
	{
		projectile.netImportant = true;
		projectile.width = 30;
		projectile.height = 30;
		projectile.friendly = true;
		projectile.aiStyle = 26;
		projectile.penetrate = -1;
		projectile.timeLeft *= 5;
		aiType = 492;
	}

	public override void AI()
	{
		Player player = Main.player[projectile.owner];
			ConfectionPlayer modPlayer = player.GetModPlayer<ConfectionPlayer>();
			if (player.dead) {
				modPlayer.birdnanaLightPet = false;
			}
			if (modPlayer.birdnanaLightPet) {
				projectile.timeLeft = 2;
			}

		if (Main.myPlayer == projectile.owner)
		{
			Lighting.AddLight(projectile.Center, 2.48f, 1.99f, 0.05f);
		}
		projectile.frameCounter++;
		if (projectile.frameCounter > 6)
		{
			projectile.frame++;
			projectile.frameCounter = 0;
		}
		if (projectile.frame > 3)
		{
			projectile.frame = 0;
		}
	}
	
	public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
			fallThrough = true;
			return true;
		}
    }
}