using BepInEx;
using BepInEx.Logging;

using HarmonyLib;

//Un-comment this to use the patch example
using StubosShowNeeds.Patches;

namespace StubosShowNeeds;

/*
  Here are some basic resources on code style and naming conventions to help
  you in your first CSharp plugin!

  https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
  https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names
  https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-namespaces
*/

[BepInPlugin(LCMPluginInfo.PLUGIN_GUID, LCMPluginInfo.PLUGIN_NAME, LCMPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
  internal static ManualLogSource Log = null!;


  private void Awake()
  {
    /*
      BepinEx makes you a ManualLogSource for free called "Logger"
      and I created a static value above to hold on to it so other
      parts of your plugin's code can find it by using Plugin.Log

      We assign it here
    */
    Log = Logger;

    

    // Log our awake here so we can see it in LogOutput.txt file
    Log.LogInfo($"Plugin {LCMPluginInfo.PLUGIN_NAME} version {LCMPluginInfo.PLUGIN_VERSION} is loaded!");

    
    //Here is an example of how you'd do a patch

    //This creates a harmony instance with your ID. It can be used
    //To possibly un-patch every method you patch or just to inspect
    //What you patch by any other code that can see harmony and
    //request the patcher by name. This is a good thing so follow
    //this standard to allow other mods to react to your patches
    //for compatibility and other reasons
    Harmony myHarmony = new(LCMPluginInfo.PLUGIN_GUID);

    //Note: you'll need to also un-comment the example patches in
    //ClassName.cs to see this actually work
    //Also Note: This will patch all [HarmonyPatch] tagged
    //Items in the class PowerSourcePatches. Its why I do things this
    //Way. You can choose which of you groups of patches to apply
    //Based on eg, settings or something.
    myHarmony.PatchAll(typeof(ShowUI));
  }

}
