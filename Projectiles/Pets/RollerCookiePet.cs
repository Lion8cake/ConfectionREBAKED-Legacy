using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles.Pets
{
	public class RollerCookiePet : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false;
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
			ConfectionPlayer modPlayer = player.GetModPlayer<ConfectionPlayer>();
			if (player.dead) {
				modPlayer.RollerCookiePet = false;
			}
			if (modPlayer.RollerCookiePet) {
				projectile.timeLeft = 2;
			}
		}
	}
}