using HarmonyLib;
using System.Reflection;

namespace SteveModTemplate.Important.Patching
{
    public static class HarmonyPatches
    {
        private static Harmony instance; // Harmony instance for applying patches

        public static bool IsPatched { get; private set; } // Indicates whether patches are currently applied
        public const string InstanceId = PluginInfo.GUID; // Unique identifier for this mod

        // Applies Harmony patches to the current assembly if they haven't been applied already
        internal static void ApplyHarmonyPatches()
        {
            if (!IsPatched) // Check if patches are already applied
            {
                // Initialize Harmony instance if it hasn't been created
                if (instance == null)
                {
                    instance = new Harmony(InstanceId);
                }

                // Apply all patches from the executing assembly
                instance.PatchAll(Assembly.GetExecutingAssembly());
                IsPatched = true; // Mark as patched
            }
        }

        // Removes all Harmony patches from the current assembly
        internal static void RemoveHarmonyPatches()
        {
            if (instance != null && IsPatched) // Check if patches are applied
            {
                instance.UnpatchSelf(); // Remove patches
                IsPatched = false; // Mark as unpatched
            }
        }
    }
}
