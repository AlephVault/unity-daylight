using System.Collections.Generic;
using AlephVault.Unity.Boilerplates.Utils;
using UnityEditor;
using UnityEngine;

namespace Editor.MenuActions.Boilerplates
{
    namespace MenuActions
    {
        namespace Boilerplates
        {
            /// <summary>
            ///   This boilerplate function creates:
            ///   - UI Toolkit/DayLight/:
            ///     - lunar-style.uss: lunar-specific theme style.
            ///     - solar-style.uss: solar-specific theme style.
            ///     - common-style.uss: common theme style.
            /// </summary>
            public static class DayLightThemeSetup
            {
                private const string PackagePath = "Packages/com.alephvault.unity.daylight";
                
                // Lunar theme colors.
                private static Color32 LunarBrightest = new Color32(33, 196, 255, 255);
                private static Color32 LunarBrighter = new Color32(29, 174, 222, 255);
                private static Color32 LunarMiddle = new Color32(25, 145, 189, 255);
                private static Color32 LunarDarker = new Color32(20, 122, 156, 255);
                private static Color32 LunarDarkest = new Color32(18, 98, 128, 255);
                // Lunar background URL:
                private static string LunarBackgroundURL = $"project://database/{PackagePath}/Runtime/Images/lunar-background.png?fileID=2800000&guid=3ce4008828c2ba4aca283cbd3e670ded&type=3#lunar-background";

                // Solar theme colors.
                private static Color32 SolarBrightest = new Color32(255, 191, 0, 255);
                private static Color32 SolarBrighter = new Color32(222, 163, 0, 255);
                private static Color32 SolarMiddle = new Color32(189, 142, 0, 255);
                private static Color32 SolarDarker = new Color32(156, 114, 0, 255);
                private static Color32 SolarDarkest = new Color32(128, 96, 0, 255);
                // Solar background URL:
                private static string SolarBackgroundURL = $"project://database/{PackagePath}/Runtime/Images/solar-background.png?fileID=2800000&guid=adf2be1c7e7228f4f8025bf6b1ba60fd&type=3#solar-background";

                // Converts a color to its RGBA expression for USS.
                private static string ToUSSColorExpression(Color32 color)
                {
                    return $"rgba({color.r}, {color.g}, {color.b}, {color.a})";
                }

                [MenuItem("Assets/Create/DayLight/Boilerplates/Theme Startup", false, 206)]
                public static void ExecuteBoilerplate()
                {
                    string directory = PackagePath + "/Editor/MenuActions/Boilerplates/Templates";

                    TextAsset specificStyle = AssetDatabase.LoadAssetAtPath<TextAsset>(
                        directory + "/specific-style.uss.txt"
                    );
                    TextAsset commonStyle = AssetDatabase.LoadAssetAtPath<TextAsset>(
                        directory + "/common-style.uss.txt"
                    );
                    
                    new Boilerplate()
                        .IntoDirectory("UI Toolkit", true)
                            .IntoDirectory("DayLight", true)
                                .Do(Boilerplate.InstantiateTemplate(
                                    specificStyle, "lunar-style", new Dictionary<string, string>
                                    {
                                        {"BRIGHTEST_COLOR", ToUSSColorExpression(LunarBrightest)},
                                        {"BRIGHTER_COLOR", ToUSSColorExpression(LunarBrighter)},
                                        {"MIDDLE_COLOR", ToUSSColorExpression(LunarMiddle)},
                                        {"DARKER_COLOR", ToUSSColorExpression(LunarDarker)},
                                        {"DARKEST_COLOR", ToUSSColorExpression(LunarDarkest)},
                                        {"CLASS", "lunar"},
                                        {"BACKGROUND_URL", LunarBackgroundURL}
                                    }
                                ))
                                .Do(Boilerplate.InstantiateTemplate(
                                    specificStyle, "solar-style", new Dictionary<string, string>
                                    {
                                        {"BRIGHTEST_COLOR", ToUSSColorExpression(SolarBrightest)},
                                        {"BRIGHTER_COLOR", ToUSSColorExpression(SolarBrighter)},
                                        {"MIDDLE_COLOR", ToUSSColorExpression(SolarMiddle)},
                                        {"DARKER_COLOR", ToUSSColorExpression(SolarDarker)},
                                        {"DARKEST_COLOR", ToUSSColorExpression(SolarDarkest)},
                                        {"CLASS", "solar"},
                                        {"BACKGROUND_URL", SolarBackgroundURL}                                    }
                                ))
                                .Do(Boilerplate.InstantiateTemplate(
                                    commonStyle, "common", new Dictionary<string, string>()
                                ))
                            .End()
                        .End();
                }
            }
        }
    }
}