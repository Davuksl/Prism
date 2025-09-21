// don't worry, your "Goldentrophy Software" isn't actual company
// yes its on GPL-3 but its free license so not surprised

using HarmonyLib;

namespace iiMenu.Patches.Safety
{
    [HarmonyPatch(typeof(GorillaNetworkPublicTestsJoin), "GracePeriod")]
    public class GNPTJ1
    {
        private static bool Prefix() =>
            false;
    }
}
