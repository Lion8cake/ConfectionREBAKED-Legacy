using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class SoulofSpite : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Soul of Spite");
			Tooltip.SetDefault("'The essence of bloody creatures'");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults() 
		{
		    Item refItem = new Item();
			refItem.SetDefaults(ItemID.SoulofNight);
			item.width = refItem.width;
			item.height = refItem.height;
			item.value = 1000;
			item.rare = ItemRarityID.Orange;
			item.maxStack = 999;
		}
		
		public override void AddRecipes()
		{
														
 		 ModRecipe recipe = new ModRecipe(mod);
 		 recipe.AddIngredient(ItemID.Feather, 10);
 		 recipe.AddIngredient(ItemID.SoulofFlight, 20);
 		 recipe.AddIngredient(null, "SoulofSpite", 25);
		 recipe.AddTile(134);
  		 recipe.SetResult(ItemID.DemonWings, 1);
  		 recipe.AddRecipe();

   		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(ItemID.Harp, 1);
   		 recipe.AddIngredient(ItemID.CrystalShard, 20);
   		 recipe.AddIngredient(null, "SoulofSpite", 8);
		 recipe.AddIngredient(ItemID.SoulofSight, 15);
    	 recipe.AddTile(134);
 		 recipe.SetResult(ItemID.MagicalHarp, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(ItemID.SpellTome, 1);
   		 recipe.AddIngredient(ItemID.CursedFlame, 20);
   		 recipe.AddIngredient(null, "SoulofSpite", 15);
    	 recipe.AddTile(101);
 		 recipe.SetResult(ItemID.CursedFlames, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(ItemID.RottenChunk, 6);
   		 recipe.AddIngredient(ItemID.IronBar, 5);
   		 recipe.AddIngredient(null, "SoulofSpite", 6);
    	 recipe.AddTile(134);
 		 recipe.SetResult(ItemID.MechanicalWorm, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(ItemID.Vertebrae, 6);
   		 recipe.AddIngredient(ItemID.IronBar, 5);
   		 recipe.AddIngredient(null, "SoulofSpite", 6);
    	 recipe.AddTile(134);
 		 recipe.SetResult(ItemID.MechanicalWorm, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(ItemID.RottenChunk, 6);
   		 recipe.AddIngredient(ItemID.LeadBar, 5);
   		 recipe.AddIngredient(null, "SoulofSpite", 6);
    	 recipe.AddTile(134);
 		 recipe.SetResult(ItemID.MechanicalWorm, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(ItemID.Vertebrae, 6);
   		 recipe.AddIngredient(ItemID.LeadBar, 5);
   		 recipe.AddIngredient(null, "SoulofSpite", 6);
    	 recipe.AddTile(134);
 		 recipe.SetResult(ItemID.MechanicalWorm, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(ItemID.Bone, 30);
   		 recipe.AddIngredient(ItemID.IronBar, 5);
		 recipe.AddIngredient(ItemID.SoulofLight, 3);
   		 recipe.AddIngredient(null, "SoulofSpite", 3);
    	 recipe.AddTile(134);
 		 recipe.SetResult(ItemID.MechanicalSkull, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(ItemID.Bone, 30);
   		 recipe.AddIngredient(ItemID.LeadBar, 5);
		 recipe.AddIngredient(ItemID.SoulofLight, 3);
   		 recipe.AddIngredient(null, "SoulofSpite", 3);
    	 recipe.AddTile(134);
 		 recipe.SetResult(ItemID.MechanicalSkull, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(ItemID.Bone, 30);
   		 recipe.AddIngredient(ItemID.IronBar, 5);
		 recipe.AddIngredient(null, "SoulofDelight", 3);
   		 recipe.AddIngredient(null, "SoulofSpite", 3);
    	 recipe.AddTile(134);
 		 recipe.SetResult(ItemID.MechanicalSkull, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(ItemID.Bone, 30);
   		 recipe.AddIngredient(ItemID.LeadBar, 5);
		 recipe.AddIngredient(null, "SoulofDelight", 3);
   		 recipe.AddIngredient(null, "SoulofSpite", 3);
    	 recipe.AddTile(134);
 		 recipe.SetResult(ItemID.MechanicalSkull, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(ItemID.SpellTome, 1);
   		 recipe.AddIngredient(ItemID.Ichor, 20);
   		 recipe.AddIngredient(null, "SoulofSpite", 15);
    	 recipe.AddTile(101);
 		 recipe.SetResult(ItemID.GoldenShower, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(null, "SoulofSpite", 5);
		 recipe.AddIngredient(ItemID.IronBar, 1);
   		 recipe.AddIngredient(ItemID.Wire, 1);
    	 recipe.AddTile(134);
 		 recipe.SetResult(ItemID.LogicSensor_Moon, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(null, "SoulofSpite", 5);
		 recipe.AddIngredient(ItemID.LeadBar, 1);
   		 recipe.AddIngredient(ItemID.Wire, 1);
    	 recipe.AddTile(134);
 		 recipe.SetResult(ItemID.LogicSensor_Moon, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(3795, 1);
   		 recipe.AddIngredient(3783, 2);
   		 recipe.AddIngredient(null, "SoulofSpite", 12);
    	 recipe.AddTile(134);
 		 recipe.SetResult(3779, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(ItemID.Shotgun, 1);
   		 recipe.AddIngredient(ItemID.DarkShard, 2);
   		 recipe.AddIngredient(null, "SoulofSpite", 10);
    	 recipe.AddTile(134);
 		 recipe.SetResult(3788, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(null, "SoulofSpite", 1);
    	 recipe.AddTile(13);
 		 recipe.SetResult(ItemID.SoulofNight, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(ItemID.SoulofNight, 1);
    	 recipe.AddTile(13);
 		 recipe.SetResult(null, "SoulofSpite", 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(null, "CanofMeat", 1);
    	 recipe.AddTile(26);
 		 recipe.SetResult(ItemID.DarkShard, 1);
  		 recipe.AddRecipe();
		 
		 recipe = new ModRecipe(mod);
   		 recipe.AddIngredient(ItemID.DarkShard, 1);
    	 recipe.AddTile(26);
 		 recipe.SetResult(null, "CanofMeat", 1);
  		 recipe.AddRecipe();
		 }
	}
}