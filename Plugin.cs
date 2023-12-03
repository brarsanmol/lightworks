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
            ConfigValues.DISCO_FLASHLIGHT_TOGGLED = this.GetConfigValue(
                "DiscoFlashlight",
                "Enabled",
                true,
                new ConfigDescription(
                    "Whether the flashlight transitions through a rainbow of colours!",
                    new AcceptableValueList<bool>(true, false)
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
