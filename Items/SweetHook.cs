using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheConfectionRebirth.Items
{
    public class SweetHook : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.IlluminantHook);
            item.shootSpeed = 18f;
            item.shoot = mod.ProjectileType("SweetHook");
        }
    }
}
