using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;

namespace Decreased_Fall_Damage
{
	// Token: 0x02000002 RID: 2
	[HarmonyPatch(typeof(Character))]
	public static class DecreasedFallDamage_Patch
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		[HarmonyPatch("UpdateGroundContact")]
		[HarmonyTranspiler]
		private static IEnumerable<CodeInstruction> UpdateGroundContact(IEnumerable<CodeInstruction> instructions)
		{
			List<CodeInstruction> list = instructions.ToList<CodeInstruction>();
			for (int i = 0; i < list.Count; i++)
			{
				bool flag = list[i].opcode == OpCodes.Ldc_R4 && object.Equals(list[i].operand, 100f);
				if (flag)
				{
					list[i] = new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(DecreasedFallDamage_Patch), "GetMaxFallDamage", null, null));
					break;
				}
			}
			return list;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020E8 File Offset: 0x000002E8
		private static float GetMaxFallDamage()
		{
			return (float)Configuration.fallDamage;
		}
	}
}

