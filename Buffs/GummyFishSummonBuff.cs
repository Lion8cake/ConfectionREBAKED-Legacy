using TheConfectionRebirth.Projectiles.Summons;
using Terraria;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Buffs
{
public class GummyFishSummonBuff : ModBuff
{
	public override void SetDefaults()
	{
		DisplayName.SetDefault("Flying Gummy Fish");
		Description.SetDefault("Flying gummy fish will fly after your enemies.");
		Main.buffNoTimeDisplay[Type] = true;
		Main.buffNoSave[Type] = true;
	}

	public override void Update(Player player, ref int buffIndex) {
			ConfectionPlayer modPlayer = player.GetModPlayer<ConfectionPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Summons.GummyFishSummonProj>()] > 0) {
				modPlayer.flyingGummyFish = true;
			}
			if (!modPlayer.flyingGummyFish) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		}
}
}