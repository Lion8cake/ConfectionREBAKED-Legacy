using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class ChocolateChunk : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Spawns a little Rollercookie to roll around with you!");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ModContent.ProjectileType<Projectiles.Pets.RollerCookiePet>();
			item.buffType = ModContent.BuffType<Buffs.RollerCookiePet>();
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}