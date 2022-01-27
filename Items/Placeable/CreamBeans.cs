using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheConfectionRebirth.Items.Placeable
{
	public class CreamBeans : ModItem
	{
	    public override void SetStaticDefaults()
	    {
	    	DisplayName.SetDefault("Cream Beans");
	    }

	    public override void SetDefaults()
	    {
	    	item.width = 16;
	    	item.height = 16;
	    	item.maxStack = 999;
	    	item.useStyle = 1;
	    	item.useAnimation = 15;
	    	item.useTime = 10;
	    	item.autoReuse = true;
	    	item.useTurn = true;
	    	item.createTile = mod.TileType("CreamGrass");
	    	item.consumable = true;
	    }

	    public override bool CanUseItem(Player player)
	    {
		    Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
    		if (tile != null && tile.active() && tile.type == 0)
		    {
		    	WorldGen.destroyObject = true;
		    	TileID.Sets.BreakableWhenPlacing[0] = true;
		    }
	    	return true;
	    }

	    public override bool UseItem(Player player)
	    {
		    WorldGen.destroyObject = false;
		    TileID.Sets.BreakableWhenPlacing[0] = false;
			return false;
		}
	}
}
