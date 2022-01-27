using Terraria.ModLoader;
using Terraria.ID;

namespace TheConfectionRebirth.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class WonkyHat : ModItem
	{
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.rare = ItemRarityID.White;
			item.vanity = true;
		}
	}
}