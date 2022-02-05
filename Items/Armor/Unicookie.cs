using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheConfectionRebirth.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class Unicookie : ModItem
	{
		public override void SetStaticDefaults() {
		Tooltip.SetDefault("'Great for impersonating Confection Creators'");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
            item.vanity = true;
			item.rare = ItemRarityID.Cyan;
		}
		
		public override bool DrawLegs() {
			return false;
		}
	}
}