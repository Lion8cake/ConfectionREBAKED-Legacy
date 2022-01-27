using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles.Pets
{
	public class CreamsandWitchPet : ModProjectile
	{
		public override void SetStaticDefaults() {
		    Main.projFrames[projectile.type] = 10;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.PetLizard);
			aiType = ProjectileID.PetLizard;
			projectile.width = 46;
			projectile.height = 45;
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
				modPlayer.CreamsandWitchPet = false;
			}
			if (modPlayer.CreamsandWitchPet) {
				projectile.timeLeft = 2;
			}
		}
	}
}