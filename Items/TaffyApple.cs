using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class TaffyApple : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons a Dudling");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LizardEgg);
			item.shoot = ModContent.ProjectileType<Projectiles.Pets.DudlingPet>();
			item.buffType = ModContent.BuffType<Buffs.DudlingPet>();
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}