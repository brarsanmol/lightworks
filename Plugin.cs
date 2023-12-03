using BepInEx;
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
            this._harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            this._harmony.PatchAll();
            Logger.LogInfo("HarmonyLib is loaded!");
            
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
