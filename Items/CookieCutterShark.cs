using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class CookieCutterShark : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cookie Cutter Shark");
		}

		public override void SetDefaults() {
			item.questItem = true;
			item.maxStack = 1;
			item.width = 26;
			item.height = 26;
			item.uniqueStack = true;
			item.rare = ItemRarityID.Quest;
		}

		public override bool IsQuestFish() {
			return true;
		}

		public override bool IsAnglerQuestAvailable() {
			return Main.hardMode;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation) {
			description = "There's a living cookie cutter down in the deep Confection! Go and bring it back for me so I can make some living cookies!";
			catchLocation = "Caught anywhere in the Confection";
		}
	}
}
