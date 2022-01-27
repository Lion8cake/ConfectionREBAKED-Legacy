using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace TheConfectionRebirth.Items.Placeable
{
    public class ConfectionCrate : ModItem
    {
	
    	public override void SetStaticDefaults()
    	{
    		DisplayName.SetDefault("Confection Crate");
    		Tooltip.SetDefault("Right Click to open");
    	}
	    
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true; 
            item.width = 34; 
            item.height = 34;      
            item.rare = ItemRarityID.Green;
            item.createTile = mod.TileType("ConfectionCrate");
            item.placeStyle = 0;
            item.useAnimation = 10; 
            item.useTime = 10; 
			item.value = 50000;
            item.useStyle = 1; 
        }
		
        public override bool CanRightClick()
        {
            return true;
        }
 
        public override void RightClick(Player player)
        {
            if (Main.hardMode)
            {
                player.QuickSpawnItem(mod.ItemType("Saccharite"), Main.rand.Next(2, 5));
                player.QuickSpawnItem(mod.ItemType("SoulofDelight"), Main.rand.Next(3, 5));
                player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(0, 1));
            }
        }
    }
}