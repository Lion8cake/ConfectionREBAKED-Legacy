using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class CreamFoxPetItem : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Lucky Creamy Fox Tail");
			Tooltip.SetDefault("Summons a Creamy Fox");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.DogWhistle);
			item.shoot = ModContent.ProjectileType<Projectiles.Pets.FoxPet>();
			item.buffType = ModContent.BuffType<Buffs.FoxPet>();
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}