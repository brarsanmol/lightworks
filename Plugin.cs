using System;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace LightWorks
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Lethal Company.exe")]
    public class Plugin : BaseUnityPlugin
    {
        private Harmony _harmony;
        
        private void Awake()
        {
            this.AssignConfigValues();
            
            this._harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            Logger.LogInfo("Loaded HarmonyLib!");
            this._harmony.PatchAll();
            this.ListPatches();
            
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        /// <summary>
        /// List each patch that HarmonyLib has applied.
        /// This includes the class name, and the method name.
        /// </summary>
        private void ListPatches()
        {
            foreach (var method in this._harmony.GetPatchedMethods())
            {
                Logger.LogInfo($"Patched {method.DeclaringType.Name}.{method.Name}");
            }
        }

        /// <summary>
        /// Retrieve each configuration value and assign it the appropriate variable in the ConfigValues class.
        /// </summary>
        private void AssignConfigValues()
        {
            this.AssignDiscoFlashlightConfigValues();
            this.AssignFlashlightConfigValues();
        }

        private void AssignDiscoFlashlightConfigValues()
        {
            ConfigValues.DISCO_FLASHLIGHT_ENABLED = this.GetConfigValue(
                "DiscoFlashlight",
                "Enabled",
                false,
                new ConfigDescription(
                    "Whether the flashlight transitions through a rainbow of colours!",
                    new AcceptableValueList<bool>(true, false)
                )
            ).Value;
            
            ConfigValues.DISCO_FLASHLIGHT_MINIMUM_SPEED = this.GetConfigValue(
                "DiscoFlashlight",
                "MinimumSpeed",
                1.0f,
                new ConfigDescription(
                    "The minimum speed of the colour transition.",
                    new AcceptableValueRange<float>(1.0f, float.MaxValue)
                )
            ).Value;
            
            ConfigValues.DISCO_FLASHLIGHT_MAXIMUM_SPEED = this.GetConfigValue(
                "DiscoFlashlight",
                "MaximumSpeed",
                1.0f,
                new ConfigDescription(
                    "The maximum speed of the colour transition.",
                    new AcceptableValueRange<float>(1.0f, float.MaxValue)
                )
            ).Value;
        }

        private void AssignFlashlightConfigValues()
        {
            ConfigValues.FLASHLIGHT_ENABLED = this.GetConfigValue(
                "Flashlight",
                "Enabled",
                true,
                new ConfigDescription(
                    "Whether the flashlight changes to a user-specified colour.",
                    new AcceptableValueList<bool>(true, false)
                )
            ).Value;
            
            ConfigValues.FLASHLIGHT_COLOUR_R = this.GetConfigValue(
                "Flashlight",
                "Red",
                249f,
                new ConfigDescription(
                    "The intensity of red.",
                    new AcceptableValueRange<float>(0f, 255f)
                )
            ).Value;
            
            ConfigValues.FLASHLIGHT_COLOUR_G = this.GetConfigValue(
                "Flashlight",
                "Green",
                238f,
                new ConfigDescription(
                    "The intensity of green.",
                    new AcceptableValueRange<float>(0f, 255f)
                )
            ).Value;
            
            ConfigValues.FLASHLIGHT_COLOUR_B = this.GetConfigValue(
                "Flashlight",
                "Blue",
                214f,
                new ConfigDescription(
                    "The intensity of blue.",
                    new AcceptableValueRange<float>(0f, 255f)
                )
            ).Value;
        }
        
        /// <summary>
        /// Retrieve a configuration value with a section and key, also allow specification of a description and default value.
        /// </summary>
        /// <param name="section">The section of the configuration file we are accessing.</param>
        /// <param name="key">The key within the section to access.</param>
        /// <param name="defaultValue">If the configuration entry does not exist, the default value to be specified.</param>
        /// <param name="description">The purpose and usage of the configuration entry.</param>
        /// <typeparam name="T">The type of the value in the ConfigEntry.</typeparam>
        /// <returns>A ConfigEntry object of type T.</returns>
        private ConfigEntry<T> GetConfigValue<T>(string section, string key, T defaultValue, ConfigDescription description)
        {
            var entry = Config.Bind(section, key, defaultValue, description);
            Logger.LogInfo($"Retrieved ConfigValue {section}.{key} as {entry.Value}");
            return entry;
        }
    }
}
