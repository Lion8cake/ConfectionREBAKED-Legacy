/*using Microsoft.Xna.Framework; //Also doesn't work and taken from exxo avalon origins remake
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace TheConfectionRebirth.Hooks
{
    public class WorldUI
    {
        public static Texture2D OnGetIcon(On.Terraria.GameContent.UI.Elements.UIWorldListItem.orig_GetIcon orig, UIWorldListItem self)
        {
            WorldFileData data = self.GetFieldValue<WorldFileData>("_data");
            var path = Path.ChangeExtension(data.Path, ".twld");

            TheConfectionRebirthConfig config = ModContent.GetInstance<TheConfectionRebirthConfig>();
            Dictionary<string, TheConfectionRebirthConfig.WorldDataValues> tempDict = config.GetWorldData();

            if (!tempDict.ContainsKey(path))
            {
                if (!FileUtilities.Exists(path, data.IsCloudSave))
                {
                    return orig(self);
                }

                //Stream stream = (data.IsCloudSave ? ((Stream)new MemoryStream(Terraria.Social.SocialAPI.Cloud.Read(path))) : ((Stream)new FileStream(path, FileMode.Open)));
                byte[] buf = FileUtilities.ReadAllBytes(path, data.IsCloudSave);
                if (buf[0] != 31 || buf[1] != 139)
                {
                    return orig(self);
                }

                var stream = new MemoryStream(buf);
                var tag = TagIO.FromStream(stream);
                bool containsMod = false;

                if (tag.ContainsKey("modData"))
                {
                    foreach (TagCompound modDataTag in tag.GetList<TagCompound>("modData").Skip(2))
                    {
                        if (modDataTag.Get<string>("mod") == TheConfectionRebirth.mod.Name)
                        {
                            TagCompound dataTag = modDataTag.Get<TagCompound>("data");
                            TheConfectionRebirthConfig.WorldDataValues worldData;

                            worldData.hallowType = dataTag.Get<int>("TheConfectionRebirth:HallowType");
                            tempDict[path] = worldData;

                            containsMod = true;

                            break;
                        }
                    }

                    if (!containsMod)
                    {
                        TheConfectionRebirthConfig.WorldDataValues worldData;

                        worldData.hallowType = (int)ConfectionWorldGeneration.HallowVariant.hallow;
                        tempDict[path] = worldData;
                    }

                    config.SetWorldData(tempDict);
                    TheConfectionRebirthConfig.Save(config);
                }
            }

            if (tempDict.ContainsKey(path))
            {
                string iconPath = "Sprites/Icon";
                iconPath += data.IsHardMode ? "Hallow" : "";
                iconPath += data.HasCrimson ? "Crimson" : "Corruption";
                iconPath += (ConfectionWorldGeneration.HallowVariant)tempDict[path].hallowType == ConfectionWorldGeneration.HallowVariant.confection ? "Confection" : "Hallow";
                return TheConfectionRebirth.mod.GetTexture(iconPath);
            }
            else
            {
                return orig(self);
            }
        }

        public static void OnEraseWorld(On.Terraria.Main.orig_EraseWorld orig, int i)
        {
            TheConfectionRebirthConfig config = ModContent.GetInstance<TheConfectionRebirthConfig>();
            Dictionary<string, TheConfectionRebirthConfig.WorldDataValues> tempDict = config.GetWorldData();
            var path = Path.ChangeExtension(Main.WorldList[i].Path, ".twld");

            if (tempDict.ContainsKey(path))
            {
                tempDict.Remove(path);
                config.SetWorldData(tempDict);
                TheConfectionRebirthConfig.Save(config);
            }
            orig(i);
        }
    }

    public static class ReflectionExtensions
    {
        public static T GetFieldValue<T>(this object obj, string name)
        {
            // Set the flags so that private and public fields from instances will be found
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var field = obj.GetType().GetField(name, bindingFlags);
            return (T)field?.GetValue(obj);
        }
    }
}*/