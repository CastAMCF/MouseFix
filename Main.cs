using System;
using System.Reflection;
using Harmony12;
using UnityModManagerNet;

namespace MouseFix {
	internal static class Main
	{

		public static bool enabled;

		public static UnityModManager.ModEntry mod;

		private static bool Load(UnityModManager.ModEntry modEntry)
		{
			Main.mod = modEntry;
			modEntry.OnToggle = new Func<UnityModManager.ModEntry, bool, bool>(Main.OnToggle);
			HarmonyInstance harmonyInstance = HarmonyInstance.Create(modEntry.Info.Id);
			harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
			return true;
		}

		private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
		{
			Main.enabled = value;
			modEntry.Logger.Log("Starting MouseFix");
			return true;
		}
	}
}