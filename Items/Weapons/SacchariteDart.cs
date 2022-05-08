using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
    public class SacchariteDart : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 10;
            item.ranged = true;
            item.width = 26;
            item.maxStack = 999;
            item.consumable = true;
            item.height = 30;

            item.shoot = mod.ProjectileType("SacchariteDartPro");
            item.shootSpeed = 22f;
            item.knockBack = 4;
            item.value = 10;
            item.rare = 3;
            item.ammo = 283;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Saccharite Dart");
            Tooltip.SetDefault("Homes onto enemies");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Saccharite", 1);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}