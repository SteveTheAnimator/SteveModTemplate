using System;

namespace SteveModTemplate.Important
{
    public static class Logs
    {
        // Logs a message to the console with the mod's GUID as a prefix
        public static void Log(string message)
        {
            Console.WriteLine($"{PluginInfo.GUID}: {message}"); // Prefix message with mod GUID
        }
    }
}
