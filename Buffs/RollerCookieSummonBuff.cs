using TheConfectionRebirth.Projectiles.Summons;
using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Buffs
{
	public class RollerCookieSummonBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Miniture Roller Cookie");
			Description.SetDefault("The Miniture Cookies will roll after your enemies.");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
	
		public override void Update(Player player, ref int buffIndex) {
			ConfectionPlayer modPlayer = player.GetModPlayer<ConfectionPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Summons.RollerCookieSummonProj>()] > 0) {
				modPlayer.minitureCookie = true;
			}
			if (!modPlayer.minitureCookie) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}