using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using StubosShowNeeds.Patches;
using System.Collections.Generic;

namespace StubosShowNeeds;

[BepInPlugin(LCMPluginInfo.PLUGIN_GUID, LCMPluginInfo.PLUGIN_NAME, LCMPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log = null!;
    internal static ConfigEntry<float> DefaultThreshold;
    internal static Dictionary<string, ConfigEntry<float>> StatThresholds;
    internal static Dictionary<string, ConfigEntry<bool>> DisabledStats;

    private void Awake()
    {
        Log = Logger;
        InitializeConfig();

        Log.LogInfo($"Plugin {LCMPluginInfo.PLUGIN_NAME} version {LCMPluginInfo.PLUGIN_VERSION} is loaded!");

        Harmony myHarmony = new(LCMPluginInfo.PLUGIN_GUID);
        myHarmony.PatchAll(typeof(ShowUI));
    }

    private void InitializeConfig()
    {
        DefaultThreshold = Config.Bind("General",
                                     "DefaultThreshold",
                                     1f,
                                     "Default threshold value for all stats (percentage)");

        StatThresholds = new Dictionary<string, ConfigEntry<float>>();
        DisabledStats = new Dictionary<string, ConfigEntry<bool>>();

        var allStats = new[]
        {
            "Health",
            "Hygiene",
            "Bleeding",
            "Hunger",
            "Thirst",
            "Sleep",
            "WC",
            "Alcohol",
            "Mushrooms",
            "Smokes",
            "Depression",
            "Ducks"
        };

        foreach (var stat in allStats)
        {
            StatThresholds[stat] = Config.Bind("StatThresholds",
                                             stat,
                                             DefaultThreshold.Value,
                                             $"Threshold for {stat} stat (percentage)");

            DisabledStats[stat] = Config.Bind("DisabledStats",
                                            stat,
                                            false,
                                            $"If true, modifications for {stat} will be disabled");
        }
    }
}
