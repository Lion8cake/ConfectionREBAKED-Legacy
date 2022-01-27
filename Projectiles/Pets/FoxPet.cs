using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Projectiles.Pets
{
	public class FoxPet : ModProjectile
	{
		public override void SetStaticDefaults() {
		    Main.projFrames[projectile.type] = 11;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Puppy);
			aiType = ProjectileID.Puppy;
			projectile.width = 68;
			projectile.height = 36;
		}

		public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			player.puppy = false;
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
			ConfectionPlayer modPlayer = player.GetModPlayer<ConfectionPlayer>();
			if (player.dead) {
				modPlayer.FoxPet = false;
			}
			if (modPlayer.FoxPet) {
				projectile.timeLeft = 2;
			}
		}
	}
}