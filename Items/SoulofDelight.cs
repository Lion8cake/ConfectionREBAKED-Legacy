using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class SoulofDelight : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Soul of Delight");
			Tooltip.SetDefault("'The essence of delightful creatures'");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults() 
		{
		    Item refItem = new Item();
			refItem.SetDefaults(ItemID.SoulofLight);
			item.width = refItem.width;
			item.height = refItem.height;
			item.value = 1000;
			item.rare = ItemRarityID.Orange;
			item.maxStack = 999;
		}
		
		public class SoulGlobalNPC : GlobalNPC
	{
		public override void NPCLoot(NPC npc) {
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneRockLayerHeight && Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ConfectionPlayer>().ZoneConfection) {
			    if (Main.rand.Next(5) == 0)
                {
				Item.NewItem(npc.getRect(), ModContent.ItemType<SoulofDelight>(), 1);
				}
			}
		}
	}
	
		public override void AddRecipes() // thanks to foxyboy55 for this fix
		{
														
 		 ModRecipe recipe = new ModRecipe(mod);
 		 recipe.AddIngredient(38, 3);
 		 recipe.AddIngredient(22, 5);
 		 recipe.AddIngredient(null, "SoulofDelight", 6);
		 recipe.AddTile(134);
  		 recipe.SetResult(544, 1);
  		 recipe.AddRecipe();

   		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(38, 3);
   		 recipe.AddIngredient(704, 5);
   		 recipe.AddIngredient(null, "SoulofDelight", 6);
    	 recipe.AddTile(134);
 		 recipe.SetResult(544, 1);
  		 recipe.AddRecipe();

  		 recipe = new ModRecipe(mod);
    	 recipe.AddIngredient(154, 30);
   		 recipe.AddIngredient(22, 5);
   		 recipe.AddIngredient(null, "SoulofDelight", 3);
   		 recipe.AddIngredient(521, 3);
    	 recipe.AddTile(134);
   		 recipe.SetResult(557, 1);
    	 recipe.AddRecipe();

		 recipe = new ModRecipe(mod);
 		 recipe.AddIngredient(154, 30);
 		 recipe.AddIngredient(704, 5);
 		 recipe.AddIngredient(null, "SoulofDelight", 3);
 		 recipe.AddIngredient(521, 3);
 		 recipe.AddTile(134);
 		 recipe.SetResult(557, 1);
 		 recipe.AddRecipe();

    	 recipe = new ModRecipe(mod);
	     recipe.AddIngredient(117, 20);
    	 recipe.AddIngredient(null, "Sprinkles", 10);
  		 recipe.AddIngredient(null, "SoulofDelight", 10);
 		 recipe.AddTile(134);
 		 recipe.SetResult(2750, 1);
 		 recipe.AddRecipe();
		}
	}
}