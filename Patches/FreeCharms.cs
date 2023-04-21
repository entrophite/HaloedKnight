using HarmonyLib;

namespace HolyKnight.Patches
{
	[HarmonyPatch(typeof(PlayerData))]
	[HarmonyPatch(nameof(PlayerData.EquipCharm))]
	internal class FreeCharmsEquipCharm
	{
		static bool Prefix(ref PlayerData __instance)
		{
			if (Plugin.config_free_charms.Value)
				for (var i = 1; i < 40; i++)
					__instance.SetInt("charmCost_" + i, 0);
			return true;
		}
	}

	[HarmonyPatch(typeof(PlayerData))]
	[HarmonyPatch(nameof(PlayerData.CalculateNotchesUsed))]
	internal class FreeCharmsCalculateNotchesUsed
	{
		static bool Prefix(ref PlayerData __instance)
		{
			if (Plugin.config_free_charms.Value)
				for (var i = 1; i < 40; i++)
					__instance.SetInt("charmCost_" + i, 0);
			return true;
		}
	}
}
