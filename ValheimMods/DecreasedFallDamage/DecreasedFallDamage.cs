using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Decreased_Fall_Damage
{
	// Token: 0x02000004 RID: 4
	[BepInPlugin("bRitch02.valheim.DecreasedFallDamage", "Decreased Fall Damage", "1.0.0")]
	[BepInProcess("valheim.exe")]
	public class DecreasedFallDamage : BaseUnityPlugin
	{
		// Token: 0x06000009 RID: 9 RVA: 0x00002404 File Offset: 0x00000604
		public void Awake()
		{
			BepInEx.Logging.Logger.Sources.Add(DecreasedFallDamage.Logger);
			Configuration.InitConfiguration();
			bool enable = Configuration.Enable;
			bool flag = enable;
			if (flag)
			{
				DecreasedFallDamage.Logger.LogWarning("[DEBUG] Patching...");
				new Harmony("bRitch02.valheim.DecreasedFallDamage").PatchAll();
				DecreasedFallDamage.Logger.LogWarning("[DEBUG] Done Patching...");
			}
			else
			{
				bool flag2 = !Configuration.Enable && Configuration.Debug;
				bool flag3 = flag2;
				if (flag3)
				{
					DecreasedFallDamage.Logger.LogWarning("[DEBUG] Mod disable, patch skipped.");
				}
			}
			DecreasedFallDamage.Logger.LogInfo("Successfully loaded DecreasedFallDamage " + "1.0.0".ToString());
		}

		// Token: 0x04000005 RID: 5
		public const string pluginGuid = "bRitch02.valheim.DecreasedFallDamage";

		// Token: 0x04000006 RID: 6
		public const string pluginName = "Decreased Fall Damage";

		// Token: 0x04000007 RID: 7
		public const string pluginVersion = "1.0.0";

		// Token: 0x04000008 RID: 8
		public new static ManualLogSource Logger = new ManualLogSource("Decreased Fall Damage");
	}
}
