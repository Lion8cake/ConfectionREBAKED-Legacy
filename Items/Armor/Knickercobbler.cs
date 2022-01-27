using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class Knickercobbler : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Knickercobbler");
		    Tooltip.SetDefault("'Great for impersonating Confection Creators'");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.vanity = true;
			item.rare = ItemRarityID.Cyan;
		}
		
		public override bool DrawBody() {
			return false;
		}
	}
}