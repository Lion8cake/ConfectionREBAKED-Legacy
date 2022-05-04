using TheConfectionRebirth.Items;
using TheConfectionRebirth.Tiles;
using TheConfectionRebirth.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using Terraria.Utilities;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConfectionRebirth
{
	public class ConfectionPlayer : ModPlayer
	{
	   public bool RollerCookiePet;
	   public bool CreamsandWitchPet;
	   public bool minitureCookie;
	   public bool littleMeawzer;
	   public bool miniGastropod;
	   public bool flyingGummyFish;
	   public bool birdnanaLightPet;
	   public bool MeawzerPet;
	   public bool DudlingPet;
	   public bool FoxPet;
	   
	   public Projectile DimensionalWarp;
	
       public bool ZoneConfection;
	   
	   public int neapoliniteArmorSetType;
	   
	   public override void ResetEffects() {
			RollerCookiePet = false;
			CreamsandWitchPet = false;
			minitureCookie = false;
			littleMeawzer = false;
			miniGastropod = false;
			flyingGummyFish = false;
			birdnanaLightPet = false;
			MeawzerPet = false;
			DudlingPet = false;
			FoxPet = false;
	   }
	   
	   public override void PreUpdateBuffs()
		{ 
			neapoliniteArmorSetType = 0;
			
			if (player.ZoneDesert && (ZoneConfection) && player.HasBuff(194))
	    	{
	    		player.ClearBuff(194);
	    	}
		}
		
	   public override void UpdateBiomes() {
			ZoneConfection = ConfectionWorld.confectionTiles > 100;
		}

		public override bool CustomBiomesMatch(Player other) {
			ConfectionPlayer modOther = other.GetModPlayer<ConfectionPlayer>();
			return ZoneConfection == modOther.ZoneConfection;
		}

		public override void CopyCustomBiomesTo(Player other) {
			ConfectionPlayer modOther = other.GetModPlayer<ConfectionPlayer>();
			modOther.ZoneConfection = ZoneConfection;
		}

		public override void SendCustomBiomes(BinaryWriter writer) {
			BitsByte flags = new BitsByte();
			flags[0] = ZoneConfection;
			writer.Write(flags);
		}

		public override void ReceiveCustomBiomes(BinaryReader reader) {
			BitsByte flags = reader.ReadByte();
			ZoneConfection = flags[0];
		}
		
		/*public override void PostUpdateMiscEffects()
        {
            if (player.GetModPlayer<ConfectionPlayer>().ZoneConfection && player.ZoneSnow)
            {
                for (int i = 0; i < 3; i++)
                {
                    Dust dust = Main.dust[Dust.NewDust(player.Center - new Vector2(800, 800), 1600, 800, mod.DustType("SnowflakeDust"), 0, 0, 0, default, 2f)];
                    dust.noLight = true;
                }
            }
        }*/
		
		public override void PostUpdateMiscEffects()
    	{
    		if (Main.netMode != 2 && player.whoAmI == Main.myPlayer)
    		{
    			Texture2D confectionrain = mod.GetTexture("Sprites/ConfectionRain");
    			Texture2D rain = mod.GetTexture("Sprites/Rain");
				Texture2D corruptionrain = mod.GetTexture("Sprites/CorruptionRain");
				Texture2D desertrain = mod.GetTexture("Sprites/DesertRain");
				Texture2D hallowedrain = mod.GetTexture("Sprites/HallowedRain");
				Texture2D icerain = mod.GetTexture("Sprites/IceRain");
				Texture2D junglerain = mod.GetTexture("Sprites/JungleRain");
				Texture2D oceanrain = mod.GetTexture("Sprites/OceanRain");
				Texture2D crimsonrain = mod.GetTexture("Sprites/CrimsonRain");
    			if (Main.bloodMoon)
    			{
	    			Main.rainTexture = rain;
	    		}
	    		else if (Main.raining && (ZoneConfection))
	    		{
	    			Main.rainTexture = confectionrain;
	    		}
				else if (Main.raining && player.ZoneCorrupt)
				{
					Main.rainTexture = corruptionrain;
				}
				else if (Main.raining && player.ZoneDesert)
				{
					Main.rainTexture = desertrain;
				}
				else if (Main.raining && player.ZoneHoly)
				{
					Main.rainTexture = hallowedrain;
				}
				else if (Main.raining && player.ZoneSnow)
				{
					Main.rainTexture = icerain;
				}
				else if (Main.raining && player.ZoneJungle)
				{
					Main.rainTexture = junglerain;
				}
				else if (Main.raining && player.ZoneBeach)
				{
					Main.rainTexture = oceanrain;
				}
				else if (Main.raining && player.ZoneCrimson)
				{
					Main.rainTexture = crimsonrain;
				}
	      		else
	    		{
	    			Main.rainTexture = rain;
	    		}
	    	}
	    }
		
		public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk) {
			if (junk) {
				return;
			}
			if (player.GetModPlayer<ConfectionPlayer>().ZoneConfection && questFish == ModContent.ItemType<CookieCutterShark>() && Main.rand.Next(10) == 0) 
			{
				caughtType = ModContent.ItemType<CookieCutterShark>();
				return;
			}
			
			if (player.GetModPlayer<ConfectionPlayer>().ZoneConfection && !Main.LocalPlayer.ZoneRockLayerHeight && questFish == ModContent.ItemType<Sprinklefish>() && Main.rand.Next(10) == 0) 
			{
				caughtType = ModContent.ItemType<Sprinklefish>();
				return;
			}
			
			if (player.GetModPlayer<ConfectionPlayer>().ZoneConfection && Main.LocalPlayer.ZoneRockLayerHeight && questFish == ModContent.ItemType<SacchariteBatFish>() && Main.rand.Next(10) == 0) 
			{
				caughtType = ModContent.ItemType<SacchariteBatFish>();
				return;
			}
			
			if (player.GetModPlayer<ConfectionPlayer>().ZoneConfection && liquidType == 0 && player.FindBuffIndex(BuffID.Crate) > -1 && Main.rand.Next(100) == 0)
            {
                caughtType = mod.ItemType("ConfectionCrate");
            }
			
			if (player.GetModPlayer<ConfectionPlayer>().ZoneConfection && liquidType == 0 && Main.rand.Next(10) == 0)
            {
                caughtType = mod.ItemType("CookieCarp");
            } 
			
			if (player.GetModPlayer<ConfectionPlayer>().ZoneConfection && liquidType == 0 && Main.rand.Next(15) == 0)
            {
                caughtType = mod.ItemType("Cakekite");
            }
			
			if (player.GetModPlayer<ConfectionPlayer>().ZoneConfection && player.ZoneRockLayerHeight && liquidType == 0 && Main.rand.Next(15) == 0)
            {
                caughtType = mod.ItemType("SugarFish");
            }
			
			if (player.GetModPlayer<ConfectionPlayer>().ZoneConfection && liquidType == 0 && Main.rand.Next(50) == 0)
			{
				caughtType = mod.ItemType("GummyStaff");
			}
		}
		
		public override Texture2D GetMapBackgroundImage() {
		    if (Main.LocalPlayer.ZoneRockLayerHeight && Main.LocalPlayer.GetModPlayer<ConfectionPlayer>().ZoneConfection) {
				return mod.GetTexture("ConfectionUndergroundMapBackground");
			}
			else if (ZoneConfection) {
				return mod.GetTexture("ConfectionBiomeMapBackground"); 
			}
			return null;
		}
		
		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
			if (damageSource.SourceCustomReason == "DimensionSplit")
			{
				WeightedRandom<string> deathmessage = new WeightedRandom<string>();
				deathmessage.Add(player.name + " got lost in a rift.");
				deathmessage.Add(player.name + " was split like a banana.");
				deathmessage.Add(player.name + " tried to banana all the time.");
				deathmessage.Add(player.name + " got split between dimensions.");
				damageSource = PlayerDeathReason.ByCustomReason(deathmessage);
				return true;
			}
			return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
		}
			
		public static readonly PlayerLayer NeapoliniteConeMailMask = new PlayerLayer("TheConfectionRebirth", "NeapoliniteConeMail_Body_Mask", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo)
		{

			if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
			{
				return;
			}

			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("TheConfectionRebirth");

			if (drawPlayer.GetModPlayer<ConfectionPlayer>().neapoliniteArmorSetType != 0)
			{
				string glowType = drawPlayer.GetModPlayer<ConfectionPlayer>().neapoliniteArmorSetType == 1 ? "A" : "B";
				Texture2D texture = mod.GetTexture("Items/Armor/NeapoliniteConeMail_Body_Mask"+glowType);

				float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
				float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;
				Vector2 origin = drawInfo.bodyOrigin;
				Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;
				float alpha = (255 - drawPlayer.immuneAlpha) / 255f;
				Color color = Color.White * drawPlayer.stealth;
				Rectangle frame = drawPlayer.bodyFrame;
				float rotation = drawPlayer.bodyRotation;
				SpriteEffects spriteEffects = drawInfo.spriteEffects;

				DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0);
				drawData.shader = drawInfo.bodyArmorShader;
				Main.playerDrawData.Add(drawData);
			}
		});
		
		public static readonly PlayerLayer NeapoliniteConeMailArmsMask = new PlayerLayer("TheConfectionRebirth", "NeapoliniteConeMail_Arms_Mask", PlayerLayer.Arms, delegate (PlayerDrawInfo drawInfo) {

			if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead) {
				return;
			}

			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("TheConfectionRebirth");

			if (drawPlayer.GetModPlayer<ConfectionPlayer>().neapoliniteArmorSetType != 0)
			{
				string glowType = drawPlayer.GetModPlayer<ConfectionPlayer>().neapoliniteArmorSetType == 1 ? "A" : "B";
				Texture2D texture = mod.GetTexture("Items/Armor/NeapoliniteConeMail_Arms_Mask"+glowType);

				float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
				float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;
				Vector2 origin = drawInfo.bodyOrigin;
				Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;
				float alpha = (255 - drawPlayer.immuneAlpha) / 255f;
				Color color = Color.White * drawPlayer.stealth;
				Rectangle frame = drawPlayer.bodyFrame;
				float rotation = drawPlayer.bodyRotation;
				SpriteEffects spriteEffects = drawInfo.spriteEffects;

				DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0);
				drawData.shader = drawInfo.bodyArmorShader;
				Main.playerDrawData.Add(drawData);
			}
		});
		
		public static readonly PlayerLayer NeapoliniteGreavesMask = new PlayerLayer("TheConfectionRebirth", "NeapoliniteGreaves_Legs_Mask", PlayerLayer.Legs, delegate (PlayerDrawInfo drawInfo) {

			if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead) {
				return;
			}

			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("TheConfectionRebirth");

			if (drawPlayer.GetModPlayer<ConfectionPlayer>().neapoliniteArmorSetType != 0)
			{
				string glowType = drawPlayer.GetModPlayer<ConfectionPlayer>().neapoliniteArmorSetType == 1 ? "A" : "B";
				Texture2D texture = mod.GetTexture("Items/Armor/NeapoliniteGreaves_Legs_Mask"+glowType);

				float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
				float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.legFrame.Height / 2 + 4f;
				Vector2 origin = drawInfo.bodyOrigin;
				Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;
				float alpha = (255 - drawPlayer.immuneAlpha) / 255f;
				Color color = Color.White * drawPlayer.stealth;
				Rectangle frame = drawPlayer.legFrame;
				float rotation = drawPlayer.bodyRotation;
				SpriteEffects spriteEffects = drawInfo.spriteEffects;

				DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0);
				drawData.shader = drawInfo.legArmorShader;
				Main.playerDrawData.Add(drawData);
			}
		});
		public static readonly PlayerLayer NeapoliniteHelmetMask = new PlayerLayer("TheConfectionRebirth", "NeapoliniteHelmet_Head_Mask", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo) {

			if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead) {
				return;
			}

			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("TheConfectionRebirth");

			Texture2D texture = mod.GetTexture("Items/Armor/NeapoliniteHelmet_Head_MaskA");

			float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
			float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;
			Vector2 origin = drawInfo.bodyOrigin;
			Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;
			float alpha = (255 - drawPlayer.immuneAlpha) / 255f;
			Color color = Color.White*drawPlayer.stealth;
			Rectangle frame = drawPlayer.bodyFrame;
			float rotation = drawPlayer.bodyRotation;
			SpriteEffects spriteEffects = drawInfo.spriteEffects;

			DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0);
			drawData.shader = drawInfo.headArmorShader;
			Main.playerDrawData.Add(drawData);
		});
		
		public static readonly PlayerLayer NeapoliniteHeadgearMask = new PlayerLayer("TheConfectionRebirth", "NeapoliniteHeadgear_Head_Mask", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo) {

			if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead) {
				return;
			}

			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("TheConfectionRebirth");

			Texture2D texture = mod.GetTexture("Items/Armor/NeapoliniteHeadgear_Head_MaskB");

			float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
			float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;
			Vector2 origin = drawInfo.bodyOrigin;
			Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;
			float alpha = (255 - drawPlayer.immuneAlpha) / 255f;
			Color color = Color.White*drawPlayer.stealth;
			Rectangle frame = drawPlayer.bodyFrame;
			float rotation = drawPlayer.bodyRotation;
			SpriteEffects spriteEffects = drawInfo.spriteEffects;

			DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0);
			drawData.shader = drawInfo.headArmorShader;
			Main.playerDrawData.Add(drawData);
		});
		
		public static readonly PlayerLayer NeapoliniteHatMask = new PlayerLayer("TheConfectionRebirth", "NeapoliniteHat_Head_Mask", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo) {

			if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead) {
				return;
			}

			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("TheConfectionRebirth");

			Texture2D texture = mod.GetTexture("Items/Armor/NeapoliniteHat_Head_MaskC");

			float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
			float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;
			Vector2 origin = drawInfo.bodyOrigin;
			Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;
			float alpha = (255 - drawPlayer.immuneAlpha) / 255f;
			Color color = Color.White*drawPlayer.stealth;
			Rectangle frame = drawPlayer.bodyFrame;
			float rotation = drawPlayer.bodyRotation;
			SpriteEffects spriteEffects = drawInfo.spriteEffects;

			DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0);
			drawData.shader = drawInfo.headArmorShader;
			Main.playerDrawData.Add(drawData);
		});
		
		public static readonly PlayerLayer NeapoliniteMaskMask = new PlayerLayer("TheConfectionRebirth", "NeapoliniteMask_Head_Mask", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo) {

			if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead) {
				return;
			}

			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("TheConfectionRebirth");

			Texture2D texture = mod.GetTexture("Items/Armor/NeapoliniteMask_Head_MaskD");

			float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
			float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;
			Vector2 origin = drawInfo.bodyOrigin;
			Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;
			float alpha = (255 - drawPlayer.immuneAlpha) / 255f;
			Color color = Color.White*drawPlayer.stealth;
			Rectangle frame = drawPlayer.bodyFrame;
			float rotation = drawPlayer.bodyRotation;
			SpriteEffects spriteEffects = drawInfo.spriteEffects;

			DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0);
			drawData.shader = drawInfo.headArmorShader;
			Main.playerDrawData.Add(drawData);
		});
		
	public static readonly PlayerLayer NeapoliniteConeMailMaskDefault = new PlayerLayer("TheConfectionRebirth", "NeapoliniteConeMail_Body_Mask", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo) {

			if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
			{
				return;
			}

			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("TheConfectionRebirth");

			string gender = "";
			if (!drawPlayer.Male)
			{
				gender = "Female";
			}

			Texture2D texture = mod.GetTexture("Items/Armor/NeapoliniteConeMail_" + gender + "Body_Mask");

			float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
			float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;
			Vector2 origin = drawInfo.bodyOrigin;
			Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;
			float alpha = (255 - drawPlayer.immuneAlpha) / 255f;
			Color color = Color.White * drawPlayer.stealth;
			Rectangle frame = drawPlayer.bodyFrame;
			float rotation = drawPlayer.bodyRotation;
			SpriteEffects spriteEffects = drawInfo.spriteEffects;

			DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0);
			drawData.shader = drawInfo.bodyArmorShader;
			Main.playerDrawData.Add(drawData);
		});
		public static readonly PlayerLayer NeapoliniteConeMailArmsMaskDefault = new PlayerLayer("TheConfectionRebirth", "NeapoliniteConeMail_Arms_Mask", PlayerLayer.Arms, delegate (PlayerDrawInfo drawInfo) {

			if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
			{
				return;
			}

			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("TheConfectionRebirth");

			Texture2D texture = mod.GetTexture("Items/Armor/NeapoliniteConeMail_Arms_Mask");

			float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
			float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;

			Vector2 origin = drawInfo.bodyOrigin;
			Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;
			float alpha = (255 - drawPlayer.immuneAlpha) / 255f;
			Color color = Color.White * drawPlayer.stealth;
			Rectangle frame = drawPlayer.bodyFrame;
			float rotation = drawPlayer.bodyRotation;
			SpriteEffects spriteEffects = drawInfo.spriteEffects;

			DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0);
			drawData.shader = drawInfo.bodyArmorShader;
			Main.playerDrawData.Add(drawData);
		}); 
		public static readonly PlayerLayer NeapoliniteGreavesMaskDefault = new PlayerLayer("TheConfectionRebirth", "NeapoliniteGreaves_Legs_Mask", PlayerLayer.Legs, delegate (PlayerDrawInfo drawInfo) {

			if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
			{
				return;
			}

			Player drawPlayer = drawInfo.drawPlayer;
			Mod mod = ModLoader.GetMod("TheConfectionRebirth");

			Texture2D texture = mod.GetTexture("Items/Armor/NeapoliniteGreaves_Legs_Mask");

			float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
			float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.legFrame.Height / 2 + 4f;
			Vector2 origin = drawInfo.bodyOrigin;
			Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;
			float alpha = (255 - drawPlayer.immuneAlpha) / 255f;
			Color color = Color.White * drawPlayer.stealth;
			Rectangle frame = drawPlayer.legFrame;
			float rotation = drawPlayer.bodyRotation;
			SpriteEffects spriteEffects = drawInfo.spriteEffects;

			DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0);
			drawData.shader = drawInfo.legArmorShader;
			Main.playerDrawData.Add(drawData);
		});
		
		public override void ModifyDrawLayers(List<PlayerLayer> layers) {

			if (player.body == mod.GetEquipSlot("NeapoliniteConeMail", EquipType.Body)) {
				int bodyLayer = layers.FindIndex(l => l == PlayerLayer.Body);

				if (bodyLayer > -1) {
					layers.Insert(bodyLayer + 1, NeapoliniteConeMailMask);
				}

				int armsLayer = layers.FindIndex(l => l == PlayerLayer.Arms);

				if (armsLayer > -1) {
					layers.Insert(armsLayer + 1, NeapoliniteConeMailArmsMask);
				}
			}

			if (player.legs == mod.GetEquipSlot("NeapoliniteGreaves", EquipType.Legs)) {
				int legsLayer = layers.FindIndex(l => l == PlayerLayer.Legs);

				if (legsLayer > -1) {
					layers.Insert(legsLayer + 1, NeapoliniteGreavesMask);
				}
			}
			
			if (player.head == mod.GetEquipSlot("NeapoliniteMask", EquipType.Head)) {
				int headLayer = layers.FindIndex(l => l == PlayerLayer.Head);

				if (headLayer > -1) {
					layers.Insert(headLayer + 1, NeapoliniteMaskMask);
				}
			}

			if (player.head == mod.GetEquipSlot("NeapoliniteHelmet", EquipType.Head)) {
				int headLayer = layers.FindIndex(l => l == PlayerLayer.Head);

				if (headLayer > -1) {
					layers.Insert(headLayer + 1, NeapoliniteHelmetMask);
				}
			}

			if (player.head == mod.GetEquipSlot("NeapoliniteHeadgear", EquipType.Head)) {
				int headLayer = layers.FindIndex(l => l == PlayerLayer.Head);

				if (headLayer > -1) {
					layers.Insert(headLayer + 1, NeapoliniteHeadgearMask);
				}
			}
			
			if (player.head == mod.GetEquipSlot("NeapoliniteHat", EquipType.Head)) {
				int headLayer = layers.FindIndex(l => l == PlayerLayer.Head);

				if (headLayer > -1) {
					layers.Insert(headLayer + 1, NeapoliniteHatMask);
				}
			}
			
			if (player.body == mod.GetEquipSlot("NeapoliniteConeMail", EquipType.Body))
			{
				int bodyLayer = layers.FindIndex(l => l == PlayerLayer.Body);

				if (bodyLayer > -1)
				{
					layers.Insert(bodyLayer + 1, NeapoliniteConeMailMaskDefault);
				}

				int armsLayer = layers.FindIndex(l => l == PlayerLayer.Arms);

				if (armsLayer > -1)
				{
					layers.Insert(armsLayer + 1, NeapoliniteConeMailArmsMaskDefault);
				}
			}

			if (player.legs == mod.GetEquipSlot("NeapoliniteGreaves", EquipType.Legs))
			{
				int legsLayer = layers.FindIndex(l => l == PlayerLayer.Legs);

				if (legsLayer > -1)
				{
					layers.Insert(legsLayer + 1, NeapoliniteGreavesMaskDefault);
				}
			}
		}
	}
}