using Terraria.ModLoader;
using Terraria.ID;

namespace TheConfectionRebirth.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ConeHead : ModItem
	
	{
	    public override void SetStaticDefaults() {
		Tooltip.SetDefault("'Great for impersonating Confection Creators'");
		}
		
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.rare = ItemRarityID.Cyan;
			item.vanity = true;
		}
	}
}