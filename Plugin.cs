// don't worry, your "Goldentrophy Software" isn't actual company
// yes its on GPL-3 but its free license so not surprised
using BepInEx;
using BepInEx.Logging;
using iiMenu.Classes.Menu;
using iiMenu.Managers;
using iiMenu.Menu;
using iiMenu.Patches;
using iiMenu.Patches.Menu;
using System.IO;
using System.Linq;
using UnityEngine;
using Console = System.Console;

namespace iiMenu
{
    [System.ComponentModel.Description(PluginInfo.Description)]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance;
        public static ManualLogSource PluginLogger => instance.Logger;
        public static bool FirstLaunch;

        private void Awake()
        {
            // Set console title
            Console.Title = $"Prism // Build {PluginInfo.Version}";
            instance = this;

            LogManager.Log($@"
    Prism  {(PluginInfo.BetaBuild ? "Beta " : "Build")} {PluginInfo.Version}
    Compiled {PluginInfo.BuildTimestamp}
    
    This program comes with ABSOLUTELY NO WARRANTY;
    for details see `https://github.com/iiDk-the-actual/iis.Stupid.Menu/GPL/WARRANTY`
    
    This is free software, and you are welcome to redistribute it under certain conditions;
    see `https://github.com/iiDk-the-actual/iis.Stupid.Menu/GPL/REDISTRIBUTION` for details.
");

            FirstLaunch = !Directory.Exists(PluginInfo.BaseDirectory);

            string[] ExistingDirectories = new string[]
            {
                "",
                "/Sounds",
                "/Plugins",
                "/Backups",
                "/TTS",
                "/PlayerInfo",
                "/CustomScripts",
                "/Friends",
                "/Friends/Messages"
            };

            foreach (string DirectoryString in ExistingDirectories)
            {
                string DirectoryTarget = $"{PluginInfo.BaseDirectory}{DirectoryString}";
                if (!Directory.Exists(DirectoryTarget))
                    Directory.CreateDirectory(DirectoryTarget);
            }

            // Ugily hard-coded but works so well
            if (File.Exists($"{PluginInfo.BaseDirectory}/DMenu_Preferences.txt"))
            {
                if (File.ReadAllLines($"{PluginInfo.BaseDirectory}/DMenu_Preferences.txt")[0].Split(";;").Contains("Accept TOS"))
                    TOSPatch.enabled = true;
            }

            if (File.Exists($"{PluginInfo.BaseDirectory}/DMenu_DisableTelemetry.txt"))
                ServerData.DisableTelemetry = true;
            
            GorillaTagger.OnPlayerSpawned(LoadMenu);
        }

        private static void LoadMenu()
        {
            PatchHandler.PatchAll();

            GameObject Loader = new GameObject("DMenu_Loader");
            Loader.AddComponent<UI>();
            Loader.AddComponent<Notifications.NotifiLib>();
            Loader.AddComponent<CoroutineManager>();

            DontDestroyOnLoad(Loader);
        }

        // For SharpMonoInjector usage
        // Don't merge these methods, it just doesn't work
        public static void Inject()
        {
            GameObject iiMenu = new GameObject("DMenu");
            iiMenu.AddComponent<Plugin>();
        }

        public static void InjectDontDestroy()
        {
            GameObject iiMenu = new GameObject("DMenu");
            iiMenu.AddComponent<Plugin>();
            DontDestroyOnLoad(iiMenu);
        }
    }
}
