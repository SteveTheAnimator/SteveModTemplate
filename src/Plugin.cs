using BepInEx;
using Photon.Pun;
using SteveModTemplate.Important.Patching; // Ensure your patching scripts are in this namespace
using System;
using UnityEngine;
using Utilla;

namespace SteveModTemplate
{
    // Dependency declaration for Utilla library
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance { get; private set; } // Singleton instance for easy access
        public static bool IsEnabled { get; private set; } // Tracks if the mod is enabled
        public static bool IsRoomModded { get; private set; } // Tracks if you are in a modded code or not.

        // Initializing event subscriptions
        public void Start()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        // Handle enabling of the mod
        public void OnEnable()
        {
            TogglePatches(true);
        }

        // Handle disabling of the mod
        public void OnDisable()
        {
            TogglePatches(false);
        }

        // Enables or disables harmony patches based on the passed boolean value
        private void TogglePatches(bool enable)
        {
            if (enable)
            {
                HarmonyPatches.ApplyHarmonyPatches(); // Apply patches
                IsEnabled = true; // Set mod status to enabled
            }
            else
            {
                HarmonyPatches.RemoveHarmonyPatches(); // Remove patches
                IsEnabled = false; // Set mod status to disabled
            }
        }

        // Called when the game is initialized, ideal for loading assets
        public void OnGameInitialized(object sender, EventArgs e)
        {
            // Insert asset loading or initialization code here
        }

        // Called once per frame, useful for updates
        public void Update()
        {
            IsRoomModded = PhotonNetwork.InRoom && PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED"); // Checks if the lobby is modded.
        }
    }

    // Basic mod information
    public class PluginInfo
    {
        internal const string
            GUID = "Steve.SteveModTemplate", // Unique identifier for the mod
            Name = "SteveModTemplate", // Display name of your mod
            Version = "1.0.0"; // Current version of your mod
    }
}
