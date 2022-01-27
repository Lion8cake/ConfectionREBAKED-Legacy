using Microsoft.Xna.Framework; // thanks to foxyboy55 for this fix
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	class ConfectionBiomeKey : ModItem
	{   
	    public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Confection Key");
            Tooltip.SetDefault("Unlocks a Confection Chest in the dungeon");
        }
		
		public override void SetDefaults()
        {
			item.width = 14;
			item.height = 20;
			item.maxStack = 99;
            item.rare = 8;
        }
        
        public class KeyGlobalNPC : GlobalNPC
	    {
	    	public override void NPCLoot(NPC npc) {
	    		if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ConfectionPlayer>().ZoneConfection) {
		    	    if (Main.rand.Next(400) == 0)
                    {
		    		Item.NewItem(npc.getRect(), ModContent.ItemType<ConfectionBiomeKey>(), 1);
		     		}
		    	}
	    	}
    	}
	}
}