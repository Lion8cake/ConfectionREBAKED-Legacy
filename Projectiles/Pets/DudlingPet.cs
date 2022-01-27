using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles.Pets
{
	public class DudlingPet : ModProjectile
	{
		public override void SetStaticDefaults() {
		    Main.projFrames[projectile.type] = 10;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.PetLizard);
			aiType = ProjectileID.PetLizard;
			projectile.width = 46;
			projectile.height = 46;
		}

		public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			player.lizard = false;
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
			ConfectionPlayer modPlayer = player.GetModPlayer<ConfectionPlayer>();
			if (player.dead) {
				modPlayer.DudlingPet = false;
			}
			if (modPlayer.DudlingPet) {
				projectile.timeLeft = 2;
			}
		}
	}
}