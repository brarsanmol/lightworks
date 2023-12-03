using HarmonyLib;
using UnityEngine;

namespace LightWorks.Patches;

[HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.Update))]
internal class DiscoFlashlightPatch
{
    private static float _time;
    
    /// <summary>
    /// The code below executes when FlashlightItem#Update is called.
    /// When applied, it causes the flashlight beam to continuously cycle through the RGB spectrum, creating a sort of "disco effect".
    /// This transition follows a sinusoidal pattern to ensure smoothness with a slight randomness in transition speed.
    /// </summary>
    /// <remarks>
    /// Color = (Mathf.Sin(time * frequency) * amplitude + offset)
    /// </remarks>
    /// <paramref name="__instance" />
    public static void Postfix(ref FlashlightItem __instance)
    {
        if (!ConfigValues.DISCO_FLASHLIGHT_TOGGLED) return;
        
        _time += Time.deltaTime * Random.Range(1.0f, 1.2f);

        var colour = new Color(
            Mathf.Sin(_time * 0.7f) * 0.5f + 0.5f,
            Mathf.Sin(_time * 0.5f) * 0.5f + 0.5f,
            Mathf.Sin(_time * 0.3f) * 0.5f + 0.5f
        );

        __instance.flashlightBulb.color = colour;
        __instance.flashlightBulbGlow.color = colour;
    }
}