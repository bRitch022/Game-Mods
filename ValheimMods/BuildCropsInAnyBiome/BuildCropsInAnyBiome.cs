using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Build_Crops_In_Any_Biome
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    [BepInProcess("valheim.exe")]
    public class BuildCropsInAnyBiome : BaseUnityPlugin
    {
        public const string pluginGuid = "ritchmods.valheim.BuildCropsInAnyBiome";
        public const string pluginName = "Build Crops In Any Biome";
        public const string pluginVersion = "1.0.1";

        public new static ManualLogSource Logger = new ManualLogSource(pluginName);

        public void Awake()
        {
            BepInEx.Logging.Logger.Sources.Add(BuildCropsInAnyBiome.Logger);

            new Harmony(pluginGuid).PatchAll();
#if DEBUG
            BuildCropsInAnyBiome.Logger.LogInfo("Successfully loaded BuildCropsInAnyBiome " + pluginVersion.ToString());
#endif
        }
    }
}
