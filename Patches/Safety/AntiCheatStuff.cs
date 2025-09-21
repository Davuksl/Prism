// don't worry, your "Goldentrophy Software" isn't actual company
// yes its on GPL-3 but its free license so not surprised

using GorillaLocomotion;
using GorillaLocomotion.Climbing;
using HarmonyLib;
using UnityEngine;

namespace iiMenu.Patches.Safety
{
    [HarmonyPatch(typeof(GTPlayer), "AntiTeleportTechnology", MethodType.Normal)]
    public class AntiTP
    {
        private static bool Prefix() =>
            false;
    }
    [HarmonyPatch(typeof(SlingshotProjectile), "CheckForAOEKnockback")]
    public class AntiKnockback
    {
        private static bool Prefix() => false;
    }
    [HarmonyPatch(typeof(GorillaVelocityTracker), "GetLatestVelocity")]
    public class VelocityPatch2
    {
        public static void Postfix(GorillaVelocityTracker __instance, ref Vector3 __result, bool worldSpace = false)
        {
            return;
        }
    }
    [HarmonyPatch(typeof(GorillaVelocityTracker), "GetAverageVelocity")]
    public class VelocityPatch
    {
        public static void Postfix(GorillaVelocityTracker __instance, ref Vector3 __result, bool worldSpace = false, float maxTimeFromPast = 0.15f, bool doMagnitudeCheck = false)
        {
            return;
        }
    }
}