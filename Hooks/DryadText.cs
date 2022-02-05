using System;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.Localization;

namespace TheConfectionRebirth.Hooks
{
    public static class DryadText
    {
        //IL.Terraria.Lang.GetDryadWorldStatusDialog += Hooks.DryadText.ILDryadText;

        public static void ILDryadText(ILContext il)
        {
            var c = new ILCursor(il);

            if (!c.TryGotoNext(i => i.MatchLdloc(0)))
                return;
            c.Remove(); // Remove Ldloc.0

            c.Emit(OpCodes.Ldloc_1);
            c.Emit(OpCodes.Ldloc_2);
            c.Emit(OpCodes.Ldloc_3);
            c.EmitDelegate<Func<int, int, int, string>>((tGood, tEvil, tBlood) =>
            {
                int tCandy = 1;

                string text = "";
                if (tGood > 0 && tEvil > 0 && tBlood > 0 && tCandy > 0)
                {
                    text = Language.GetTextValue("Mods.TheConfectionRebirth.DryadSpecialText.WorldStatusAll", Main.worldName, tGood, tEvil, tBlood, tCandy);
                }

                else if (tGood > 0 && tEvil > 0 && tBlood > 0)
                {
                    text = Language.GetTextValue("DryadSpecialText.WorldStatusAll", Main.worldName, tGood, tEvil, tBlood);
                }
                else if (tCandy > 0 && tEvil > 0 && tBlood > 0)
                {
                    text = Language.GetTextValue("Mods.TheConfectionRebirth.DryadSpecialText.WorldStatusCandyCorruptCrimson", Main.worldName, tCandy, tEvil, tBlood);
                }

                else if (tGood > 0 && tEvil > 0)
                {
                    text = Language.GetTextValue("DryadSpecialText.WorldStatusHallowCorrupt", Main.worldName, tGood, tEvil);
                }
                else if (tCandy > 0 && tEvil > 0)
                {
                    text = Language.GetTextValue("Mods.TheConfectionRebirth.DryadSpecialText.WorldStatusCandyCorrupt", Main.worldName, tCandy, tEvil);
                }
                else if (tGood > 0 && tBlood > 0)
                {
                    text = Language.GetTextValue("DryadSpecialText.WorldStatusHallowCrimson", Main.worldName, tGood, tBlood);
                }
                else if (tCandy > 0 && tBlood > 0)
                {
                    text = Language.GetTextValue("Mods.TheConfectionRebirth.DryadSpecialText.WorldStatusCandyCrimson", Main.worldName, tCandy, tBlood);
                }
                else if (tEvil > 0 && tBlood > 0)
                {
                    text = Language.GetTextValue("DryadSpecialText.WorldStatusCorruptCrimson", Main.worldName, tEvil, tBlood);
                }

                else if (tEvil > 0)
                {
                    text = Language.GetTextValue("DryadSpecialText.WorldStatusCorrupt", Main.worldName, tEvil);
                }
                else if (tBlood > 0)
                {
                    text = Language.GetTextValue("DryadSpecialText.WorldStatusCrimson", Main.worldName, tBlood);
                }

                else
                {
                    if ((tGood + tCandy) <= 0)
                    {
                        return Language.GetTextValue("DryadSpecialText.WorldStatusPure", Main.worldName);
                    }
                    else
                    {
                        if (tCandy > 0)
                        {
                            text = Language.GetTextValue("Mods.TheConfectionRebirth.DryadSpecialText.WorldStatusCandy", Main.worldName, tCandy);
                        }
                        else
                        {
                            text = Language.GetTextValue("DryadSpecialText.WorldStatusHallow", Main.worldName, tGood);
                        }
                    }
                }

                string str;
                if ((tGood + tCandy) * 1.2 >= (tEvil + tBlood) && (tGood + tCandy) * 0.8 <= (tEvil + tBlood))
                {
                    str = Language.GetTextValue("DryadSpecialText.WorldDescriptionBalanced");
                }
                else if ((tGood + tCandy) >= (tEvil + tBlood))
                {
                    str = Language.GetTextValue("DryadSpecialText.WorldDescriptionFairyTale");
                }
                else if ((tEvil + tBlood) > (tGood + tCandy) + 20)
                {
                    str = Language.GetTextValue("DryadSpecialText.WorldDescriptionGrim");
                }
                else if ((tEvil + tBlood) <= 10)
                {
                    str = Language.GetTextValue("DryadSpecialText.WorldDescriptionClose");
                }
                else
                {
                    str = Language.GetTextValue("DryadSpecialText.WorldDescriptionWork");
                }

                return $"{text} {str}";
            });

            c.Emit(OpCodes.Ret);
        }
    }
}
