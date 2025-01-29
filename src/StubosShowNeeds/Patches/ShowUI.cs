using HarmonyLib;
using System.Text;
using System.Collections.Generic;

namespace StubosShowNeeds.Patches;
public class ShowUI
{
    [HarmonyPatch(typeof(PlayerStatsUI), nameof(PlayerStatsUI.UpdateColor))]
    [HarmonyPrefix]
    static void Prefix(PlayerStatUI stat, float value, ref bool invisible, ref bool greenToRed)
    {
        // Skip if stat is disabled in config
        if (Plugin.DisabledStats.TryGetValue(stat.name, out var disabled) && disabled.Value)
        {
            return;
        }

        // Get threshold for this stat
        if (Plugin.StatThresholds.TryGetValue(stat.name, out var threshold))
        {
            // Special case for Bleeding due to its default value of 50
            if (stat.name == "Bleeding")
            {
                invisible = value == 50f;
                return;
            }

            // For all other stats
            invisible = value <= threshold.Value;
        }
        else
        {
            // Fallback to default threshold if stat isn't in config
            invisible = value <= Plugin.DefaultThreshold.Value;
        }
    }
}//;