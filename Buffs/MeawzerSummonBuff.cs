using TheConfectionRebirth.Projectiles.Summons;
using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Buffs
{
	public class MeawzerSummonBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Little Meawzer");
			Description.SetDefault("The little Meawzers will shoot rainbow lazers at your enemies.");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
	
		public override void Update(Player player, ref int buffIndex) {
				ConfectionPlayer modPlayer = player.GetModPlayer<ConfectionPlayer>();
				if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Summons.MeawzerSummonProj>()] > 0) {
					modPlayer.littleMeawzer = true;
				}
				if (!modPlayer.littleMeawzer) {
					player.DelBuff(buffIndex);
					buffIndex--;
				}
				else {
					player.buffTime[buffIndex] = 18000;
				}
			}
	}
}