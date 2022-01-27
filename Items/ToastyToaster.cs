using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class ToastyToaster : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons a Meowzer pet");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ModContent.ProjectileType<Projectiles.Pets.MeawzerPet>();
			item.buffType = ModContent.BuffType<Buffs.MeawzerPet>();
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}