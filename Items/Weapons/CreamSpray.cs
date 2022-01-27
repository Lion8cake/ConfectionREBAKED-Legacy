using TheConfectionRebirth.Items;
using TheConfectionRebirth.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
public class CreamSpray : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Cream Spray");
		Tooltip.SetDefault("Shoots a Spray of Cream");
	}

	public override void SetDefaults()
	{
		item.damage = 21;
		item.magic = true;
		item.mana = 8;
		item.width = 28;
		item.height = 30;
		item.useTime = 6;
		item.useAnimation = 26;
		item.useStyle = 5;
		item.noMelee = true;
		item.knockBack = 2f;
		item.value = 400000;
		item.rare = ItemRarityID.Pink;
		item.UseSound = SoundID.Item17;
		item.autoReuse = true;
		item.shoot = ModContent.ProjectileType<CreamySpray>();
		item.shootSpeed = 16f;
	}
}
}