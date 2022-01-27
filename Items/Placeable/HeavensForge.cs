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

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalShard, 10);
            recipe.AddIngredient(409, 30);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Saccharite", 10);
            recipe.AddIngredient(null, "Creamstone", 30);
            recipe.AddIngredient(null, "SoulofDelight", 8);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalShard, 1);
            recipe.SetResult(null, "Saccharite", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Saccharite", 1);
            recipe.SetResult(ItemID.CrystalShard, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PixieDust, 1);
            recipe.SetResult(null, "Sprinkles", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Sprinkles", 1);
            recipe.SetResult(ItemID.PixieDust, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NeapoliniteBar", 1);
            recipe.SetResult(ItemID.HallowedBar, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 1);
            recipe.SetResult(null, "NeapoliniteBar", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HallowedOre", 1);
            recipe.SetResult(null, "NeapoliniteOre", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NeapoliniteOre", 1);
            recipe.SetResult(null, "HallowedOre", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HallowedBrick", 1);
            recipe.SetResult(null, "NeapoliniteBrick", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NeapoliniteBrick", 1);
            recipe.SetResult(null, "HallowedBrick", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HallowedBrickWall", 1);
            recipe.SetResult(null, "NeapoliniteBrickWall", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NeapoliniteBrickWall", 1);
            recipe.SetResult(null, "HallowedBrickWall", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedKey, 1);
            recipe.SetResult(null, "ConfectionBiomeKey", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ConfectionBiomeKey", 1);
            recipe.SetResult(ItemID.HallowedKey, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RainbowBrick, 1);
            recipe.SetResult(null, "SherbetBricks", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SherbetBricks", 1);
            recipe.SetResult(ItemID.RainbowBrick, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RainbowBrickWall, 1);
            recipe.SetResult(null, "SherbetWall", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SherbetWall", 1);
            recipe.SetResult(ItemID.RainbowBrickWall, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RainbowTorch, 1);
            recipe.SetResult(null, "SherbetTorch", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SherbetTorch", 1);
            recipe.SetResult(ItemID.RainbowTorch, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.UnicornHorn, 1);
            recipe.SetResult(null, "CookieDough", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CookieDough", 1);
            recipe.SetResult(ItemID.UnicornHorn, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pearlwood, 1);
            recipe.SetResult(null, "CreamWood", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CreamWood", 1);
            recipe.SetResult(ItemID.Pearlwood, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofLight, 1);
            recipe.SetResult(null, "SoulofDelight", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SoulofDelight", 1);
            recipe.SetResult(ItemID.SoulofLight, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Prismite, 1);
            recipe.SetResult(null, "Cakekite", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Cakekite", 1);
            recipe.SetResult(ItemID.Prismite, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PrincessFish, 1);
            recipe.SetResult(null, "CookieCarp", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CookieCarp", 1);
            recipe.SetResult(ItemID.PrincessFish, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pwnhammer, 1);
            recipe.SetResult(null, "GrandSlammer", 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GrandSlammer", 1);
            recipe.SetResult(ItemID.Pwnhammer, 1);
            recipe.AddTile(null, "HeavensForgeTile");
            recipe.AddRecipe();
        }
    }
}