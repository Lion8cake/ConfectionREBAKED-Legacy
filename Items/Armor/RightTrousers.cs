using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheConfectionRebirth.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class RightTrousers : ModItem
	{
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
            item.vanity = true;
			item.rare = ItemRarityID.White;
		}
	}
}