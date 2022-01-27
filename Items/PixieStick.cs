using TheConfectionRebirth.Mounts;
using TheConfectionRebirth.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class PixieStick : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Pixie Stick");
			Tooltip.SetDefault("Summons a Pixie Stick to ride on");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 250000;
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
			item.mountType = ModContent.MountType<PixieStickMount>();
		}
	}
}