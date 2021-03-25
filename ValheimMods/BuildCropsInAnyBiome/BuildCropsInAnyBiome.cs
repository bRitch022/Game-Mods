using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Build_Crops_In_Any_Biome
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    [BepInProcess("valheim.exe")]
    public class BuildCropsInAnyBiome : BaseUnityPlugin
    {
        public const string pluginGuid = "bRitch02.valheim.BuildCropsInAnyBiome";
        public const string pluginName = "Build Crops In Any Biome";
        public const string pluginVersion = "1.0.1";

        public new static ManualLogSource Logger = new ManualLogSource(pluginName);

        public void Awake()
        {
            BepInEx.Logging.Logger.Sources.Add(BuildCropsInAnyBiome.Logger);

            new Harmony(pluginGuid).PatchAll();

            BuildCropsInAnyBiome.Logger.LogInfo("Successfully loaded BuildCropsInAnyBiome " + pluginVersion.ToString());
        }
    }
}
