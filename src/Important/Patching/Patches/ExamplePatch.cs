using HarmonyLib;

namespace SteveModTemplate.Important.Patching.Patches
{
    // Harmony patch for the Plugin class to modify the OnGameInitialized method
    [HarmonyPatch(typeof(Plugin))]
    [HarmonyPatch("OnGameInitialized", MethodType.Normal)]
    internal class ExamplePatch
    {
        // Method that runs after the original OnGameInitialized method
        private static void Postfix()
        {
            Logs.Log("Game initialization complete!"); // Log message to indicate initialization
        }
    }
}
