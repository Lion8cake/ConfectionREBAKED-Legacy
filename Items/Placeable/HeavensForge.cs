using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Placeable
{
    public class HeavensForge : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 26;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 4;
            item.value = 150;
            item.createTile = mod.TileType("HeavensForgeTile");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heavenly Forge");
            Tooltip.SetDefault("Allows you to convert hallowed materials into their confection alternatives and vice versa\n" +
                "'A forge created from the both the lands of rainbows and candy'");
        }

        public override void AddRecipes()
        {
			
			//main recipe
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalShard, 10);
            recipe.AddIngredient(409, 30);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe(); //the tile recipe

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Saccharite", 10);
            recipe.AddIngredient(null, "Creamstone", 30);
            recipe.AddIngredient(null, "SoulofDelight", 8);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe(); //the tile recipe
			
			//Crystal
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalShard, 1);
            recipe.SetResult(null, "Saccharite", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Saccharite

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Saccharite", 1);
            recipe.SetResult(ItemID.CrystalShard, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Crystal Shard
			
			//main mob drops
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PixieDust, 1);
            recipe.SetResult(null, "Sprinkles", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Sprinkles

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Sprinkles", 1);
            recipe.SetResult(ItemID.PixieDust, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Pixie Dust
			
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofLight, 1);
            recipe.SetResult(null, "SoulofDelight", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Soul of Delight

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SoulofDelight", 1);
            recipe.SetResult(ItemID.SoulofLight, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Soul of Light
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.UnicornHorn, 1);
            recipe.SetResult(null, "CookieDough", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //cookie dough

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CookieDough", 1);
            recipe.SetResult(ItemID.UnicornHorn, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //unicorn horn
			
			//mech bars
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NeapoliniteBar", 1);
            recipe.SetResult(ItemID.HallowedBar, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Hallowed bar

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 1);
            recipe.SetResult(null, "NeapoliniteBar", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Neapolinite Bar

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HallowedOre", 1);
            recipe.SetResult(null, "NeapoliniteOre", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Neapolinite Ore

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NeapoliniteOre", 1);
            recipe.SetResult(null, "HallowedOre", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Hallowed Ore

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HallowedBrick", 1);
            recipe.SetResult(null, "NeapoliniteBrick", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Neapolinite Brick

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NeapoliniteBrick", 1);
            recipe.SetResult(null, "HallowedBrick", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); // Hallowed Brick

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HallowedBrickWall", 1);
            recipe.SetResult(null, "NeapoliniteBrickWall", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Neapolinite Brick Wall

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NeapoliniteBrickWall", 1);
            recipe.SetResult(null, "HallowedBrickWall", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Hallowed Brick Wall
			
			//biome key
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedKey, 1);
            recipe.SetResult(null, "ConfectionBiomeKey", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Confection Biome Key

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ConfectionBiomeKey", 1);
            recipe.SetResult(ItemID.HallowedKey, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Hallowed Biome Key
			
			//Colour change brick
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RainbowBrick, 1);
            recipe.SetResult(null, "SherbetBricks", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Sherbet brick

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SherbetBricks", 1);
            recipe.SetResult(ItemID.RainbowBrick, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Rainbow Brick

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RainbowBrickWall, 1);
            recipe.SetResult(null, "SherbetWall", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Sherbet wall

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SherbetWall", 1);
            recipe.SetResult(ItemID.RainbowBrickWall, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Rainbow Brick Wall
 
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RainbowTorch, 1);
            recipe.SetResult(null, "SherbetTorch", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //sherbet torch

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SherbetTorch", 1);
            recipe.SetResult(ItemID.RainbowTorch, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //rainbow torch

			//wood
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pearlwood, 1);
            recipe.SetResult(null, "CreamWood", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //creamwood

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CreamWood", 1);
            recipe.SetResult(ItemID.Pearlwood, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //pearlwood

			//fish
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Prismite, 1);
            recipe.SetResult(null, "Cakekite", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Cakekite

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Cakekite", 1);
            recipe.SetResult(ItemID.Prismite, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Prismite

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PrincessFish, 1);
            recipe.SetResult(null, "CookieCarp", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Cookie Carp

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CookieCarp", 1);
            recipe.SetResult(ItemID.PrincessFish, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Princess Fish
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pwnhammer, 1);
            recipe.SetResult(null, "GrandSlammer", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Grandslammer

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GrandSlammer", 1);
            recipe.SetResult(ItemID.Pwnhammer, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Pwnhammer
			
			//tiles
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PearlstoneBlock, 1);
            recipe.SetResult(null, "Creamstone", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Creamstone

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Creamstone", 1);
            recipe.SetResult(ItemID.PearlstoneBlock, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Pearlstone
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedSeeds, 1);
            recipe.SetResult(null, "CreamBeans", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Cream Beans

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CreamBeans", 1);
            recipe.SetResult(ItemID.HallowedSeeds, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Hallowed seeds
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PearlsandBlock, 1);
            recipe.SetResult(null, "Creamsand", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Creamsand

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Creamsand", 1);
            recipe.SetResult(ItemID.PearlsandBlock, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Pearlsand
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(3339, 1);
            recipe.SetResult(null, "Creamsandstone", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Creamsandstone

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Creamsandstone", 1);
            recipe.SetResult(3339, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Pearlsandstone
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(3338, 1);
            recipe.SetResult(null, "HardenedCreamsand", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Hardened Creamsand

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HardenedCreamsand", 1);
            recipe.SetResult(3338, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Hardened Pearlsand
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PinkIceBlock, 1);
            recipe.SetResult(null, "OrangeIce", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Orange Ice

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "OrangeIce", 1);
            recipe.SetResult(ItemID.PinkIceBlock, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe(); //Pink Ice 
        } 
    }
}