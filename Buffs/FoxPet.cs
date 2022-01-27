using Terraria;
using Terraria.ModLoader;
using TheConfectionRebirth.Projectiles.Pets;

namespace TheConfectionRebirth.Buffs
{
	public class FoxPet : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Creamy Fox Pet");
			Description.SetDefault("\"A Creamy fox is following you!\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<ConfectionPlayer>().FoxPet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.FoxPet>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.FoxPet>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}