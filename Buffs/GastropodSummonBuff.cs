using TheConfectionRebirth.Projectiles.Summons;
using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Buffs
{
public class GastropodSummonBuff : ModBuff
{
	public override void SetDefaults()
	{
		DisplayName.SetDefault("Mini Gastropod");
		Description.SetDefault("The Mini Gastropod will shoot pink lazers at your enemies.");
		Main.buffNoTimeDisplay[Type] = true;
		Main.buffNoSave[Type] = true;
	}

	public override void Update(Player player, ref int buffIndex) {
			ConfectionPlayer modPlayer = player.GetModPlayer<ConfectionPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Summons.GastropodSummonProj>()] > 0) {
				modPlayer.miniGastropod = true;
			}
			if (!modPlayer.miniGastropod) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		}
}
}