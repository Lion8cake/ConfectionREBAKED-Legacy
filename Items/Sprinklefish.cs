using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class Sprinklefish : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sprinklefish");
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
			description = "Remember those piles of sprinkles in the confection? Well turns out sometimes some of those sprinkles grow fins and swim away. Go catch me one so I can eat it!";
			catchLocation = "Caught anywhere in the Confection Surface";
		}
	}
}
