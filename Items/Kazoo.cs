using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class Kazoo : ModItem
	{
		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.useTime = 30;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = 10000;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/kazooSound");
			item.autoReuse = true;
		}
	}
}