using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace Build_Crops_In_Any_Biome
{
    [HarmonyPatch(typeof(Plant))]
    public static class BuildCropsInAnyBiome_Patch
    {
        [HarmonyPatch("UpdateHealth")]
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> UpdateHealth(IEnumerable<CodeInstruction> instructions)
        {
            var list = instructions.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                // Modify 'WrongBiome'
                if (
                    list[i].opcode == OpCodes.Ldarg_0 &&
                    list[i + 1].opcode == OpCodes.Ldc_I4_3 &&
                    list[i + 2].opcode == OpCodes.Stfld)
                {
                    list[i + 1] = new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(BuildCropsInAnyBiome_Patch), "CheckForPlantCover"));
                    list[i + 2] = new CodeInstruction(OpCodes.Nop);

                    break;
                }

            }

            return list;
        }

        static void CheckForPlantCover(Plant __instance)
        {
            if (__instance.HaveRoof())
            {
                __instance.m_status = Plant.Status.Healthy;
                return;
            }
            else
            {
                __instance.m_status = Plant.Status.WrongBiome;
                return;
            }
        }
    }
}
