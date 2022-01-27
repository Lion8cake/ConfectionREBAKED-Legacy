using TheConfectionRebirth.Projectiles.Summons;
using TheConfectionRebirth.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheConfectionRebirth.Items.Weapons
{
	public class GastropodStaff : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons a Mini Gastropod to fight for you");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 28;
			item.summon = true;
			item.mana = 10;
			item.width = 26;
			item.height = 28;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item44;
			item.shoot = ModContent.ProjectileType<GastropodSummonProj>();
			item.buffType = ModContent.BuffType<Buffs.GastropodSummonBuff>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalShard, 25);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ModContent.ItemType<ShellBlock>(), 80);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
