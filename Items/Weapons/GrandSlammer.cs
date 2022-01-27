using TheConfectionRebirth.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
	public class GrandSlammer : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Strong enough to destroy Demon Altars");
		}

		public override void SetDefaults() {
			item.damage = 24;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 15;
			item.useAnimation = 15;
			item.hammer = 85;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 39000;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}
