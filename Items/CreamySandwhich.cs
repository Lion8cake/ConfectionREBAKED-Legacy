using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class CreamySandwhich : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons a little Creamsand Witch");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LizardEgg);
			item.shoot = ModContent.ProjectileType<Projectiles.Pets.CreamsandWitchPet>();
			item.buffType = ModContent.BuffType<Buffs.CreamsandWitchPet>();
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}