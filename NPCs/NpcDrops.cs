using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace TheConfectionRebirth.NPCs
{
    public class NpcDrops : GlobalNPC
    {
        public override void NPCLoot(NPC npc) //I like all the drops lined up and organised. This has all npc drop loot apart from the Meowzer and prickster as they were made by other people
        {
 
            if (npc.type == mod.NPCType("Rollercookie"))
            {
                if (Main.rand.Next(0) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CookieDough"), Main.rand.Next(1, 2));
                }
				
                if (Main.rand.Next(100) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChocolateChunk"), 1);
                }
				
                if (Main.rand.Next(20) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CookieMask"), 1);
                }
				
				if (Main.rand.Next(20) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CookieShirt"), 1);
                }
				
				if (Main.rand.Next(20) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CookiePants"), 1);
                }
			}	
			if (npc.type == mod.NPCType("Rollercookie_2"))
            {
                if (Main.rand.Next(0) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CookieDough"), Main.rand.Next(1, 2));
                }
				
                if (Main.rand.Next(100) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChocolateChunk"), 1);
                }
				
                if (Main.rand.Next(20) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CookieMask"), 1);
                }
				
				if (Main.rand.Next(20) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CookieShirt"), 1);
                }
				
				if (Main.rand.Next(20) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CookiePants"), 1);
                }
			}
			if (npc.type == mod.NPCType("BirthdayCookie"))
            {
                if (Main.rand.Next(0) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CookieDough"), Main.rand.Next(1, 2));
                }
				
                if (Main.rand.Next(100) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChocolateChunk"), 1);
                }
				
                if (Main.rand.Next(0) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TopCake"), 1);
                }
				
				if (Main.rand.Next(0) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BirthdaySuit"), 1);
                }
				
				if (Main.rand.Next(0) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RightTrousers"), 1);
                }
			}
		    if (npc.type == mod.NPCType("ParfaitSlime"))
            {
                if (Main.rand.Next(0) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, Main.rand.Next(1, 3));
                }
			}	
			if (npc.type == mod.NPCType("ParfaitSlime_2"))
            {
                if (Main.rand.Next(0) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, Main.rand.Next(1, 3));
                }
			}
			if (npc.type == mod.NPCType("CrazyCone"))
            {
                if (Main.rand.Next(100) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Nazar, Main.rand.Next(1));
                }
			}
		    if (npc.type == mod.NPCType("SweetGummy"))
            {
                if (Main.rand.Next(10) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CreamPuff"), 1);
                }
				
                if (Main.rand.Next(100) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TrifoldMap, 1);
                }
				
				if (Main.rand.Next(95) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GummyMask"), 1);
                }
				
				if (Main.rand.Next(95) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GummyShirt"), 1);
                }
				
				if (Main.rand.Next(95) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GummyPants"), 1);
                }
			}
			if (npc.type == mod.NPCType("SweetGummy_1"))
            {
                if (Main.rand.Next(10) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CreamPuff"), 1);
                }
				
                if (Main.rand.Next(100) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TrifoldMap, 1);
                }
				
				if (Main.rand.Next(95) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GummyMask"), 1);
                }
				
				if (Main.rand.Next(95) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GummyShirt"), 1);
                }
				
				if (Main.rand.Next(95) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GummyPants"), 1);
                }
			}
			if (npc.type == mod.NPCType("SweetGummy_2"))
            {
                if (Main.rand.Next(10) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CreamPuff"), 1);
                }
				
                if (Main.rand.Next(100) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TrifoldMap, 1);
                }
				
				if (Main.rand.Next(95) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GummyMask"), 1);
                }
				
				if (Main.rand.Next(95) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GummyShirt"), 1);
                }
				
				if (Main.rand.Next(95) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GummyPants"), 1);
                }
			}
			if (npc.type == mod.NPCType("SweetGummy_3"))
            {
                if (Main.rand.Next(10) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CreamPuff"), 1);
                }
				
                if (Main.rand.Next(100) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TrifoldMap, 1);
                }
				
				if (Main.rand.Next(95) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GummyMask"), 1);
                }
				
				if (Main.rand.Next(95) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GummyShirt"), 1);
                }
				
				if (Main.rand.Next(95) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GummyPants"), 1);
                }
			}
			if (npc.type == mod.NPCType("WildWilly"))
            {
                if (Main.rand.Next(10) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CcretTicket"), 1);
                }
				
				if (Main.rand.Next(0) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WonkyHat"), 1);
                }
				
				if (Main.rand.Next(0) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WonkyCoat"), 1);
                }
				
				if (Main.rand.Next(0) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WonkyTrousers"), 1);
                }
			}
			if (npc.type == mod.NPCType("FoaminFloat"))
            {
                if (Main.rand.Next(100) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CcretTicket"), 1);
                }
			}
			if (npc.type == mod.NPCType("SherbetSlime"))
            {
                if (Main.rand.Next(0) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SherbetBricks"), 45);
                }
			}
			if (npc.type == mod.NPCType("StripedPigron"))
            {
                if (Main.rand.Next(3) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bacon, 1);
                }
			}
			if (npc.type == mod.NPCType("MeetyMummy"))
            {
				if (Main.rand.Next(10) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CanofMeat"), 1);
                }
				if (Main.rand.Next(95) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyMask, 1);
                }
				if (Main.rand.Next(95) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyShirt, 1);
                }
				if (Main.rand.Next(95) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MummyPants, 1);
                }
				if (Main.rand.Next(100) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TrifoldMap, 1);
                }
				if (Main.rand.Next(100) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Megaphone, 1);
                }
			}
			if (npc.type == mod.NPCType("BigMimicConfection")) //Thanks to Neobind for making the mimic texture. Love ur work X3
            {    
			    int num = Main.rand.Next(4);
	        	if (num == 0)
	        	{
    	    		Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CookieCrumbler"), 1, noBroadcast: false, -1);
      	       	}
    	    	if (num == 1)
	        	{
	         		Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SweetTooth"), 1, noBroadcast: false, -1);
	        	}
	        	if (num == 2)
	        	{
	         		Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SweetHook"), 1, noBroadcast: false, -1);
	         	}
	        	if (num == 3)
	        	{
	        		Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CreamSpray"));
	        	} 
                if (Main.rand.Next(0) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GreaterHealingPotion, 10);
                }
                if (Main.rand.Next(0) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GreaterManaPotion, 10);
                }
			}
			if (npc.type == mod.NPCType("Sprinkling"))
            {
                if (Main.rand.Next(2) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Sprinkles"), 1);
                }
			}
			if (npc.type == NPCID.Gastropod)
            { 
			    if (Main.rand.Next(5) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShellBlock"), 15);
                }
			}
			if (npc.type == mod.NPCType("Iscreamer"))
            {
                if (Main.rand.Next(100) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BearClaw"), 1);
                }
				if (Main.rand.Next(500) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DimensionSplit"), 1);
                }
			}
			if (npc.type == mod.NPCType("Iscreamer_2"))
            {
                if (Main.rand.Next(100) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BearClaw"), 1);
                }
				if (Main.rand.Next(500) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DimensionSplit"), 1);
                }
			}
			if (npc.type == mod.NPCType("CreamsandWitchPhase2"))
			{
				if (Main.rand.Next(5) == 0)
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CreamHat"), 1);
				}
				if (Main.rand.Next(5) == 0)
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CookieCorset"), 1);
				}
				if (Main.rand.Next(5) == 0)
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CakeDress"), 1);
				}
				if (Main.rand.Next(1) == 0)
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Creamsand"), Main.rand.Next(30, 50));
				}
				if (Main.rand.Next(10) == 0)
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PixieStick"), 1);
				}
				if (Main.rand.Next(10) == 0)
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CreamySandwhich"), 1);
				}
			}
			if (npc.type == mod.NPCType("TheUnfirm"))
			{
				if (Main.rand.Next(33) == 0)
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AdmiralHat"), 1);
				}
                if (Main.rand.Next(0) == 0)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Marshmallow, Main.rand.Next(20, 30));
                }
			}
			if (npc.type == mod.NPCType("Dudley"))
			{
				if (Main.rand.Next(80) == 0)
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TaffyApple"), 1);
				}
			}
		}
	 }
}
