using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class CreamSolution : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cream Solution");
			Tooltip.SetDefault("Used by the Clentaminator"
				+ "\nSpreads the Confection");
		}

		public override void SetDefaults() {
			item.shoot = ModContent.ProjectileType<Projectiles.CreamSolution>() - ProjectileID.PureSpray;
			item.ammo = AmmoID.Solution;
			item.width = 10;
			item.height = 12;
			item.value = Item.buyPrice(0, 0, 25, 0);
			item.rare = ItemRarityID.Orange;
			item.maxStack = 999;
			item.consumable = true;
		}
	}
}
