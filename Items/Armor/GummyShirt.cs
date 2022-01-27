using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class GummyShirt : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Gummy Shirt");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.vanity = true;
			item.rare = ItemRarityID.Blue;
		}
	}
}