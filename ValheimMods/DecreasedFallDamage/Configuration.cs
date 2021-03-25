using System;
using System.IO;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;

namespace Decreased_Fall_Damage
{
	// Token: 0x02000003 RID: 3
	public static class Configuration
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002100 File Offset: 0x00000300
		public static bool Enable
		{
			get
			{
				return Configuration._enable.Value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x0000211C File Offset: 0x0000031C
		public static int fallDamage
		{
			get
			{
				return Configuration._fallDamage.Value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002138 File Offset: 0x00000338
		public static bool Debug
		{
			get
			{
				return Configuration._debug.Value;
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002154 File Offset: 0x00000354
		public static void InitConfiguration()
		{
			Configuration.InitValues();
			Configuration.CheckConfiguration();
			bool value = Configuration._debug.Value;
			bool flag = value;
			if (flag)
			{
				ManualLogSource logger = DecreasedFallDamage.Logger;
				string data = " [DEBUG] Configuration.initConfiguration : enable = " + Configuration._enable.Value.ToString();
				logger.LogWarning(data);
				DecreasedFallDamage.Logger.LogWarning(" [DEBUG] Configuration.initConfiguration: fallDamage = " + Configuration._fallDamage.Value.ToString());
				ManualLogSource logger2 = DecreasedFallDamage.Logger;
				string data2 = " [DEBUG] Configuration.initConfiguration : debug = " + Configuration._debug.Value.ToString();
				logger2.LogWarning(data2);
			}
			Configuration._configFile.Save();
			DecreasedFallDamage.Logger.LogInfo("Successfully loaded configuration");
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002224 File Offset: 0x00000424
		private static void InitValues()
		{
			Configuration._configFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "DecreasedFallDamage.cfg"), true);
			Configuration._enable = Configuration._configFile.Bind<bool>("General", "enable", true, "Description : Enable / disable the mod" + Environment.NewLine + "Values : true; false");
			Configuration._fallDamage = Configuration._configFile.Bind<int>("General", "fallDamage", 1, "Description : Fall damage rate. Default : 1" + Environment.NewLine + "Values : 0 - 100");
			Configuration._debug = Configuration._configFile.Bind<bool>("Debug", "debug", false, "Description : Enable / disable the debug mode" + Environment.NewLine + "Values : true; false");
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000022D8 File Offset: 0x000004D8
		private static void CheckConfiguration()
		{
			bool flag = Configuration._enable.Value && !Configuration._enable.Value;
			bool flag2 = flag;
			if (flag2)
			{
				DecreasedFallDamage.Logger.LogWarning("Config \"enable\" was reset to default : true (before " + Configuration._enable.Value.ToString() + ")");
				Configuration._enable.Value = true;
			}
			bool flag3 = Configuration._fallDamage.Value < 0 || Configuration._fallDamage.Value > 100;
			bool flag4 = flag3;
			if (flag4)
			{
				DecreasedFallDamage.Logger.LogWarning("Config \"fallDamage\" was reset to default : 0 (before " + Configuration._fallDamage.Value.ToString() + ")");
				Configuration._fallDamage.Value = 0;
			}
			bool flag5 = !Configuration._debug.Value || Configuration._debug.Value;
			bool flag6 = !flag5;
			if (flag6)
			{
				DecreasedFallDamage.Logger.LogWarning("Config \"debug\" was reset to default : true (before " + Configuration._debug.Value.ToString() + ")");
				Configuration._debug.Value = false;
			}
		}

		// Token: 0x04000001 RID: 1
		private static ConfigFile _configFile;

		// Token: 0x04000002 RID: 2
		private static ConfigEntry<bool> _enable;

		// Token: 0x04000003 RID: 3
		private static ConfigEntry<int> _fallDamage;

		// Token: 0x04000004 RID: 4
		private static ConfigEntry<bool> _debug;
	}
}

