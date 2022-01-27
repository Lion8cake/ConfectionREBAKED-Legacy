using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheConfectionRebirth.Items.Weapons;

namespace TheConfectionRebirth.Items
{
	public class HeavenGift : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Heaven's Gift");
			Tooltip.SetDefault("<right> For either Pwnhammer or Grandslammer");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.rare = ItemRarityID.Green;
		}

		public override bool CanRightClick() 
		{
		    if (Main.hardMode == true) {
			    return true;
			}
			else 
			{
			return false;
			}
		}

		public override void RightClick(Player player) 
		{
	    	if (ConfectionWorldGeneration.confectionorHallow)
            {
			    player.QuickSpawnItem(ModContent.ItemType<GrandSlammer>(), 1);
		    }
			else
			{
				player.QuickSpawnItem(367, 1);
			}
		}
	}
}