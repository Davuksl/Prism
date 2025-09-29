// Woooo, it's scary that a non-existent company will sue me💀💀
namespace iiMenu
{
    public static class PluginInfo
    {
        public const string GUID = "com.dmenu.gorillatag.prism";
        public const string Name = "Prism";
        public const string Description = "nothing";
        public const string Version = "1.0";
        public const string BuildTimestamp = "2025-09-28T10:46:40Z";
        public const string BaseDirectory = "Prism";
        public const string ResourceURL = "https://github.com/iiDk-the-actual/ModInfo/raw/main";

#if DEBUG
        public static bool BetaBuild = true;
#else
        public static bool BetaBuild = false;
#endif
    }
}
