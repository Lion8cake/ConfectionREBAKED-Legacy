using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items
{
	public class SacchariteBatFish : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Saccharite Bat Fish");
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
			description = "I think the confection is the only place where bats don't co-exist with their surroundings but it turns out that the bats that are infected with the confection turn into FISH! These fish glow a blue colour from the saccharite crystals. Go get one so I can see if its sweet!";
			catchLocation = "Caught anywhere in the Confection Underground";
		}
	}
}
