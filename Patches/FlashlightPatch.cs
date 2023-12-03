using HarmonyLib;
using UnityEngine;

namespace LightWorks.Patches;

[HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.Update))]
internal class FlashlightPatch
{
    private static readonly float DIVISOR = 255f;
    private static readonly Color _colour;

    static FlashlightPatch()
    {
        _colour = new Color(
            ConfigValues.FLASHLIGHT_COLOUR_R / DIVISOR,
            ConfigValues.FLASHLIGHT_COLOUR_G / DIVISOR,
            ConfigValues.FLASHLIGHT_COLOUR_B / DIVISOR
        );
    }
    
    /// <summary>
    /// The code below executes when FlashlightItem#Update is called.
    /// When applied, it causes the flashlight beam to change to a colour of the users choosing.
    /// </summary>
    /// <paramref name="__instance" />
    public static void Postfix(ref FlashlightItem __instance)
    {
        if (!ConfigValues.FLASHLIGHT_ENABLED) return;
        
        __instance.flashlightBulb.color = _colour;
        __instance.flashlightBulbGlow.color = _colour;
    }
}