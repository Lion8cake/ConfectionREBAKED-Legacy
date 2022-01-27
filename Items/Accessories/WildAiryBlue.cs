using TheConfectionRebirth.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheConfectionRebirth.Items.Accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.Wings })] 
	public class WildAiryBlue : ModItem
	{
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = 400000;
			item.rare = ItemRarityID.Yellow;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 145;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 2f;
			constantAscend = 0.1f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 15f;
			acceleration *= 2.5f;
		}
		
		public override bool WingUpdate(Player player, bool inUse)
    	{
	    	int WingTicks = ((!inUse) ? 8 : 6);
	    	if (player.velocity.Y != 0f)
    		{
    			player.wingFrameCounter++;
    			if (player.wingFrameCounter > WingTicks)
    			{
	    			player.wingFrame++;
	    			player.wingFrameCounter = 0;
	     			if (player.wingFrame >= 3)
	    			{
	    				player.wingFrame = 0;
	     			}
	    		}
	    	}
	    	else
	     	{
	    		player.wingFrame = 4;
	    	}
	    	return true;
	    }
	}
}