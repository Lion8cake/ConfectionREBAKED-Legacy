using TheConfectionRebirth.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
	public class SweetTooth : ModItem
	{
		public override void SetDefaults() {
			item.damage = 60;
			item.ranged = true;
			item.width = 40; 
			item.height = 20;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut; 
			item.noMelee = true;
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 11;
			item.shootSpeed = 30f;
            item.value = 400000;
			item.useAmmo = AmmoID.Arrow;
		}
	}
}
