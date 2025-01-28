using HarmonyLib;
using System.Text;
using System.Collections.Generic;

namespace StubosShowNeeds.Patches;
public class ShowUI
{
    //The player may not have these addictions all the time, so we won't show them 24/7
    private static readonly HashSet<string> conditionalNeeds = new()
    {
        "Alcohol",
        "Ducks",
        "Mushrooms",
        "Smokes"
    };

    [HarmonyPatch(typeof(PlayerStatsUI), nameof(PlayerStatsUI.UpdateColor))]
    [HarmonyPrefix]
    static void Prefix(PlayerStatUI stat, float value, ref bool invisible, ref bool greenToRed)
    {
        // Special case for Bleeding due to its default value of 50 for some reason
        if (stat.name == "Bleeding")
        {
            invisible = value == 50f;
            return;
        }

        // For other conditional needs
        if (conditionalNeeds.Contains(stat.name))
        {
            invisible = value <= 1f;
            return;
        }

        // For non-conditional needs, always show
        invisible = false;
    }
}